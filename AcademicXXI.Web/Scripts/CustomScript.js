/// <reference path="jquery-2.2.3.min.js" />

$(document).ready(function () {

    var dialog = null;

    var $btnRemovePlan = $("#btnRemovePlan");


    var $frmUI = $("#frmUI");
    var $btnConfirm = $("#btnConfirm");
    var $Messages = $("#Messages");
    var $btnClose = $("#btnClose");
    var $frmFindStudent = $("#frmFindStudent");
    var $listPlanStudent = $("#listPlanStudent");

    var StudentActive = null;
    var StudyPlanActive = null;

    $("#myStudyPlan").hide();
    
    //Display all Study Plan and add event click
    $("#listPlan a").each(function () {
        $(this).click(function () {
            var self = $(this);
            $("#selectedPlan").val(self.data('plancode')).attr({
                'data-plancode': self.data('plancode'),
            });
            StudyPlanActive = {
                'plan_name': self.data('planname'),
                'plan_code': self.data('plancode')
            };
        });
    });

    //btnFindStudent get a student from db and show it
    $("#btnFindStudent").click(function (event) {

        event.preventDefault();
        var $form = $("#frmFindStudent");

        var _StudentFound = $("#StudentFound");
        if (_StudentFound.val()) {
            _StudentFound.removeAttr("value");
        }

        var _myStudyPlan = $("#myStudyPlan");

        $.ajax({
            url: $form.attr('action'),
            data: $form.serialize(),
            method: $form.attr('method'),
            dataType: "json",
            success: function (data, status, jqXHR) {
                var result = JSON.parse(data);
                if (result != null) {
                    _StudentFound.val(result.FullName).attr({
                        'data-registernumber': result.RegisterNumber,
                        'data-documentid': result.DocumentID
                    });
                    StudentActive = {
                        FullName: result.FullName,
                        RegisterNumber: result.RegisterNumber,
                        DocumentID : result.DocumentID
                    }

                    console.log("Selected Student:");
                    console.log('FullName ' + StudentActive.FullName + ' RegisterNumber ' + StudentActive.RegisterNumber);

                    _myStudyPlan.find("#listPlanStudent").empty();
                    _myStudyPlan.show('slow');

                    var _listPlanStudent = _myStudyPlan.find("#listPlanStudent");

                    $.each(result.StudentPlans, function (index, item) {
                        _listPlanStudent.append("<a href='javascriptd:void(0)' data-plancode=" + item.StudyPlan.Code + " class='list-group-item'> *" + item.StudyPlan.Code + " " + item.StudyPlan.Name + "</a>");
                    });
                }
            },
            error: function (jqXHR, status, error) {

                _StudentFound.val(error).removeAttr("data-registernumber data-id data-documentid");
                StudentActive = null;

                _myStudyPlan.find("#listPlanStudent").empty();
                _myStudyPlan.hide('slow');
            },
            beforeSend: function () {
                _StudentFound.val("Buscando.....");
            }

        });

    });

   
    //btnAddPlan allow to add Study Plan to Student List Plan
    $("#btnAddPlan").click(function (event) {
        event.preventDefault();
        var exitPlan = false;

        if (StudentActive == null) {
            alert("Debe debe tener un estudiante seleccionado para agregar plan");
            return false;
        }

        if (StudyPlanActive == null) {
           alert('Debes seleccionar un Plan de estudio.');
            return false;
        }


        var $listPlanStudent_a = $("#listPlanStudent a")

        $listPlanStudent_a.each(function (index, item) {

            if ($(this).data("plancode") === StudyPlanActive.plan_code) {
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

    $("#btnConfirm").click(function (event) {

        event.preventDefault();
        console.log("Student" + StudentActive.FullName + ' ' + StudentActive.DocumentID );
        console.log('Plan to Add' + StudyPlanActive.plan_name + ' ' + StudyPlanActive.plan_code);

        var createJSON = {
            registernumber: StudentActive.RegisterNumber,
            documentid: StudentActive.DocumentID,
            plancode: StudyPlanActive.plan_code,
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

                $Messages.empty().append('<span class="alert alert-danger">' + result.Message + '</span>')
            },
            beforeSend: function () {

                $Messages.text("Procesando...");
            }
        })
    })




    $btnClose.click(function () {

        dialog.dialog("close");
    })

    $btnRemovePlan.click(function () {
        $selectedPlan.empty()
    });

    

    
})