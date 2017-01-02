using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.RecordRepository
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }

        public bool ExitRecord(string SAcademicYear, string selectAddSubject)
        {
            return DbSet.Any(r => r.SemesterFK.Equals(SAcademicYear) && r.SubjectFK.Equals(selectAddSubject));
        }

        public List<RecordDetails> GetAllSessionBySubject(string selectedAcademicSemester, string selectedSubject)
        {
            return GetGenericDbSet<RecordDetails>()
                .Where(r => r.SemesterFK.Equals(selectedAcademicSemester) && r.SubjectFK.Equals(selectedSubject))
                .ToList();
        }

        public RecordDetails GetRecordWithRecordDetailsByRDId(string recordDetailsid)
        {
            var _DbSetRecordDetails = GetGenericDbSet<RecordDetails>();
            var result = _DbSetRecordDetails.Include(x => x.Record)
                                .Where(x => x.RecordDetailId.Equals(recordDetailsid))
                                .SingleOrDefault();

            return result;
        }

        public Record GetRecordWithSubjectAndSessions(string subjectCode, string semesterCode)
        {
            var record = DbSet.Include(r => r.RecordDetails)
                              .Include(s => s.Subject).Include("RecordDetails.Professor")
                              .Where(r => r.SemesterFK.Equals(semesterCode) && r.SubjectFK.Equals(subjectCode));
            return record.SingleOrDefault();
        }

        public List<SpRecordStudent> RecordStudent(string RecordDetailId)
        {
            var result = GetStoreProcedure<SpRecordStudent>("Sp_RecordStudent", "@RecordDetailId", RecordDetailId);
            return result;
        }

        public bool UpdateLineRecordStudentDetail(List<SpRecordStudent> list)
        {
            var db = GetDatabase();
            var LineRecord = GetGenericDbSet<LineRecordStudentDetails>();

            try
            {
                db.BeginTransaction();
                var recordDetailID = list[0].RecordDetailId;
                var line = LineRecord.Where(l => l.RecordDetailsFK.Equals(recordDetailID)).ToList();

                if (line.Count() == list.Count)
                {
                    foreach (var item in line)
                    {
                        foreach (var item2 in list)
                        {
                            if (item.StudentFK.Equals(item2.StudentID) && item.LineRecordStudentID.Equals(item2.LineRecordStudentID))
                            {
                                item.NumericScore = item2.NumericScore;
                                item.LiteralScore = item2.LiteralScore;
                                break;
                            }
                        }
                    }
                    Save();
                    db.CurrentTransaction.Commit();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                db.CurrentTransaction.Rollback();
                ex.ToString();
                return false;
            }
            return true;
        }

        public bool ValidateIfGivenSubject(string RecordDetailId, string StudentRegisterNumber)
        {
            var dbRecordDetails = GetGenericDbSet<RecordDetails>();

            var record = dbRecordDetails.Include("Record").Include(x => x.Record.Subject).Where(r => r.RecordDetailId.Equals(RecordDetailId)).SingleOrDefault();
            var subject = record.Record.Subject;

            var dbSetStudent = GetGenericDbSet<Student>();

            var student = dbSetStudent.Include("LineRecordStudentDetails.RecordDetails.Record.Semester")
                                  .Include("LineRecordStudentDetails.RecordDetails.Record.Subject")
                                  .Where(x => x.RegisterNumber.Equals(StudentRegisterNumber)).SingleOrDefault();

            var line = student.LineRecordStudentDetails.Where(x => x.RecordDetails.Record.Subject.Code.Equals(subject.Code)).ToList();

            var rr = line.Any(x => x.RecordDetails.Record.Subject.Code.Equals(subject.Code) && x.RecordDetails.Record.SemesterFK.Equals(record.SemesterFK));

            if (rr)
            {
                return true;
            }

            bool hasLiteral = false;
            foreach (var item in line.OrderBy(x => x.RecordDetails.Record.Semester.SemesterCode))
            {
                if (item.RecordDetails.Record.Subject.Code.Equals(subject.Code))
                {
                    if (item.NumericScore.HasValue)
                    {
                        if (item.NumericScore.Value >= 70)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        switch (item.LiteralScore)
                        {
                            case "A":
                                hasLiteral = true;
                                break;

                            case "B":
                                hasLiteral = true;
                                break;

                            case "C":
                                hasLiteral = true;
                                break;
                        }
                    }
                }
            }
            return hasLiteral;
        }
    }
}