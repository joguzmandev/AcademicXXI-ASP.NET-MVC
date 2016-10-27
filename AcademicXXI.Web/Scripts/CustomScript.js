/// <reference path="jquery-2.2.3.min.js" />

$(document).ready(function () {

    var dialog = null;
    var $myStudyPlan = $("#myStudyPlan");
    var $selectedPlan = $("#selectedPlan");
    var $btnRemovePlan = $("#btnRemovePlan");
    var $btnAddPlan = $("#btnAddPlan");
    var $StudentFound = $("#StudentFound");
    var $frmUI = $("#frmUI");
    var $btnConfirm = $("#btnConfirm");
    var $Messages = $("#Messages");
    var $btnClose = $("#btnClose");
    var $btnFindStudent = $("#btnFindStudent");
    var $frmFindStudent = $("#frmFindStudent");
    var $listPlanStudent = $("#listPlanStudent");

    $myStudyPlan.hide();

    var $listPlan_a = $("#listPlan a");

    $listPlan_a.each(function () {

        $(this).click(function () {

            var self = $(this);

            var result = "<span class='label label-default'>Plan Seleccionado</span>";

            var data = '<h5 id="IdPlan" data-plancode=' + self.data('plancode') + ' data-planid=' + self.data('id') + '>' + self.data('plancode') + '</h5>';

            $selectedPlan.html(result + " " + data);
        })
    });

    $btnRemovePlan.click(function () {

        $selectedPlan.empty()
    });

    $btnAddPlan.click(function (event) {

        event.preventDefault();

        var exitPlan = false;

        var $studentSelected = $StudentFound;

        var $selectedPlan_h5 = $("#selectedPlan h5");

        if (!$studentSelected.data("registernumber")) {

            alert("Debe debe tener un estudiante seleccionado para agregar plan");

            return false;
        }

        if (!$selectedPlan_h5.data('planid')) {

            alert('Debes seleccionar un Plan de estudio.');

            return false;
        }
        var $listPlanStudent_a = $("#listPlanStudent a")

        $listPlanStudent_a.each(function (index, item) {

            if ($(this).data("id") === $selectedPlan_h5.data("planid")) {

                alert("Plan seleccionado ya está relacionado al estudiante");

                exitPlan = true;

                return false;
            }
        });

        if (!exitPlan) {

            dialog = $frmUI.dialog({

                autoOpen: true,

                height: 200,

                width: 400,

                modal: true,

                beforeClose: function () {

                    $btnConfirm.removeAttr('disabled');

                    $Messages.empty();
                }
            });
        }
    });

    $btnClose.click(function () {

        dialog.dialog("close");
    })

    $btnFindStudent.click(function (event) {

        event.preventDefault();

        var $form = $frmFindStudent;

        $StudentFound.empty()

        $.ajax({

            url: $form.attr('action'),

            data: $form.serialize(),

            method: $form.attr('method'),

            dataType: "json",

            success: function (data, status, jqXHR) {

                var result = JSON.parse(data);

                $StudentFound.text(result.FullName + " " + result.RegisterNumber).attr({
                    'data-RegisterNumber': result.RegisterNumber,
                    'data-Id': result.Id,
                    'data-DocumentID': result.DocumentID
                });

                $myStudyPlan.show('slow');

                $listPlanStudent.empty();

                $.each(result.StudentPlans, function (index, item) {

                    $listPlanStudent.append("<a href='javascriptd:void(0)' data-id=" + item.StudyPlan.Id + " data-plancode=" + item.StudyPlan.Code + " class='list-group-item'> *" + item.StudyPlan.Code + " " + item.StudyPlan.Name + "</a>");

                });
            },
            error: function (jqXHR, status, error) {

                $StudentFound.text(error).removeAttr("data-RegisterNumber data-Id data-DocumentID");

                $myStudyPlan.hide('slow');
            },
            beforeSend: function () {

                $("#StudentFound").text("Buscando.....");
            }

        })

    })

    $btnConfirm.click(function (event) {

        event.preventDefault();

        var $selectedPlan_h5 = $("#selectedPlan h5");

        //Get StudyPlan
        var plancode = $selectedPlan_h5.data("plancode");

        var planid = $selectedPlan_h5.data("planid");

        //Get Studen 
        var registernumber = $StudentFound.data("registernumber");

        var studentid = $StudentFound.data("id");

        var documentid = $StudentFound.data("documentid");

        var createJSON = {

            registernumber: registernumber,

            studentid: studentid,

            documentid: documentid,

            plancode: plancode,

            planid: planid
        }

        $.ajax({

            url: "/Student/AddPlanToStudent",

            method: "post",

            data: createJSON,

            dataType: "json",

            success: function (data, status, jqXHR) {

                var result = JSON.parse(data);

                $Messages.empty().append('<span class="alert alert-success">' + result.Message + '</span>')

                $btnConfirm.attr('disabled', 'true');

                var $form = $frmFindStudent;

                $.ajax({

                    url: $form.attr('action'),

                    data: $form.serialize(),

                    method: $form.attr('method'),

                    dataType: "json",

                    success: function (data, status, jqXHR) {

                        var result = JSON.parse(data);

                        $listPlanStudent.empty();

                        $.each(result.StudentPlans, function (index, item) {

                            $listPlanStudent.append("<a href='javascriptd:void(0)' data-id=" + item.StudyPlan.Id + " data-plancode=" + item.StudyPlan.Code + " class='list-group-item'> *" + item.StudyPlan.Code + " " + item.StudyPlan.Name + "</a>");
                        });
                    }
                })
            },
            error: function (jqXHR, status, error) {

                console.log(error)
            },
            beforeSend: function () {

                $Messages.text("Procesando...");
            }
        })
    })
})