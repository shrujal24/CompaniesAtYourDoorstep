using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe
{
    public class CommonMessage
    {
        #region Constructor
        public CommonMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Error Message
        public static string ErrorRequiredField(string FieldName)
        {
            return "Enter " + FieldName;
        }

        public static string ErrorRequiredFieldDDL(string FieldName)
        {
            return "Select " + FieldName;
        }

        public static string ErrorDuplicateFiled(string FieldName)
        {
            return FieldName + " for given data already exists.";
        }

        public static string ErrorInvalidFile(string FieldName)
        {
            return "Invalid " + FieldName + " Type or Size  in Attachment";
        }

        public static string ErrorPleaseCorrectFollowing()
        {
            return "Please Correct Following Errors <br/>";
        }
        public static string ErrorPleaseSelectAtLeastOneItem(string ItemName)
        {
            return "Select at least one " + ItemName;
        }

        public static string NoRecordFound()
        {
            return "No Record Found";
        }

        public static string NullDataMessage(String Param)
        {
            return "NullDataMessage";
        }

        public static string ErrorInvalidField(string FieldName)
        {
            return "Invalid " + FieldName;
        }

        public static string ErrorLockedRecordEdit(string FieldName)
        {
            return FieldName + " is locked hence you cannot change.";
        }
        public static string ErrorLockedRecordDelete(string FieldName)
        {
            return FieldName + " is locked hence you cannot delete.";
        }
        #endregion Error Message

        public static string PWDEmailSendSuccess(String Email)
        {
            return "Password has been sent to Email <b>" + Email + "</b>";
        }
        public static string PWDEmailSendError()
        {
            return "Error while sending Password to Email. Please try after Sometime.";
        }

        public static string PWDSMSSendSuccess(String MobileNo)
        {
            return "Password has been sent to Mobile No <b>" + MobileNo + "</b>";
        }
        public static string PWDSMSSendError()
        {
            return "Error while sending Password to Mobile No. Please try after Sometime.";
        }

        #region Record Save, Delete, Update
        public static string RecordSaved()
        {
            return "Record Saved Successfully";
        }
        public static string DeletedRecord()
        {
            return "Record Deleted Successfully";
        }
        public static string RecordUpdated()
        {
            return "Details Updated Successfully";
        }
        #endregion Record Save, Delete, Update

        #region Pagination Message
        public static string PageDisplayMessage(int Offset, int CurrentRowCount, int TotalRecords, int PageNo, int TotalPages)
        {
            return "(Showing <strong>" + (Offset + 1).ToString() + "</strong> to <strong>" + (CurrentRowCount + Offset).ToString() + "</strong> of <strong>" + TotalRecords + "</strong> records" + ", Page : <strong>" + PageNo + "</strong> of <strong>" + TotalPages + "</strong>)";
        }
        #endregion Pagination Message

        public static String Please_Enter_Atleast_One_Value = "Please enter atleast one value";
        public static String Please_Select_Atleast_One_Staff = "Please select atleast one staff";
        public static String No_such_Enrollment_No_found = "No such Enrollment No found";
        public static String Please_Enter_EnrollmentNo = "Please Enter Enrollment No.";
        public static String Please_Enter_Valid_EnrollmentNo = "Please Enter valid Enrollment No.";
        public static String Mismatch_in_internal_head_mark = "Mismatch in internal head mark";
        public static String No_Block_Available_for_Resource_mapping = "No Block Available for Resource mapping";
        public static String Select_Atleast_One_Subject = "Select atleast one subject";
        public static String No_Student_Found_In_this_Block = "No Student Found In this Block";
        public static String No_student_available_with_current_selection = "No student available with current selection";
        public static String Please_Select_at_Least_one_Display_Field = "Please Select at Least one Display Field";
        public static String No_student_found_to_generate_Schedule = "No student found to generate Schedule";
        public static String No_Schedule_Found = "No Schedule Found";
        public static String Student_Password_Reseted_Successfully = "Student Password Reset Successfully ,check Student Email for new Pasword.";
        public static String Staff_Password_Reseted_Successfully = "Staff Password Reset Successfully ,check Staff Email for new Pasword.";
        public static String Error_While_Sending_Email_To_Student = "Error while sending Email to Student";
        public static String Error_While_Sending_Email_To_Staff = "Error while sending Email to Staff";
        public static String Error_While_Sending_SMS_To_Student = "Error while sending SMS to Student";
        public static String Student_dont_have_valid_email_address_please_enter_valid_email_before_Reset_Password = "Student don't have valid Email ,Please enter valid Email before Reset Password";
        public static String Staff_dont_have_valid_institute_email_address_please_enter_valid_email_before_Reset_Password = "Staff don't have valid Email ,Please enter valid Email before Reset Password";
        public static String No_such_Institute_Email_Found = "No Such Institute Email Found";
        public static String Menu_Updated_Successfully_For_UserGroup = "Menu Updated Successfully For Selected User Group.";
        public static String Menu_Updated_Successfully_For_User = "Menu Updated Successfully For Selected User.";
        public static String Menu_Updated_Successfully_For_DutyType = "Menu Updated Successfully For Selected Duty Type.";
        public static String No_Menu_available_for_Assign_selected_User_Group = "No Menu available for Assign selected User Group.";
        public static String No_Menu_available_for_Assign_selected_User = "No Menu available for Assign selected User.";
        public static String No_Menu_available_for_Assign_selected_Duty_Type = "No Menu available for Assign selected Duty Type.";
        public static String No_User_Available_with_current_selection = "No User available with current selection";
        public static String User_Successfully_updated_for_selected_User_Group = "User Successfully updated for selected User Group.";
        public static String Student_List_Updated_For_Selected_Elective_Group_Subject = "Student List updated for selected Elective Group Subject";
        public static String Sorry_Time_for_Rechecking_application_is_over_for_this_exam = "Sorry, Time for Rechecking application for this exam is over or not started yet.";
        public static String Exam_Schedule_not_Published_or_not_Entered = "Exam Schedule not Published or not Entered";
        public static String No_Staff_available_recommend_as_supervisor = "No Staff available for Recommend as Supervisor";
        public static String No_Coordinator_available_to_allocate_duty = "No Coordinator available to allocate duty";
        public static String Duty_Updated_successfully_for_selected_Coordinator = "Duty Updated successfully for selected Coordinator";
        public static String No_Supervisor_has_duty_in_this_day_Please_allocate_duty_first = "No Supervisor has duty in this day, Please allocate duty first";
        public static String No_Block_available_to_allocate_Supervisor = "No Block available to allocate Supervisor";
        public static String Block_Successfully_allocated_to_selected_Supervisor = "Block Successfully allocated to selected Supervisor";
        public static String No_Block_Found_for_Supervision = "No Block Found for Supervision";
        public static String Student_Eligibility_updated_successfully = "Student Eligibility updated successfully.";
        public static String No_Reviewer_found_for_Approval = "No Reviewer found for Approval.";
        public static String Exemption_Status_of_student_for_selected_subject_is_updated_successfully = "Exemption Status of student for selected subject is updated successfully.";
        public static String No_pending_Attendance_found_in_selected_exam = "No pending Attendance found in selected exam.";
        public static String No_Exam_found_in_selected_criteria = "No Exam found in selected criteria.";
        public static String Enrollment_No_Locked_Successfully = "Enrollment No. Locked Successfully";
        public static String Enrollment_No_UnLocked_Successfully = "Enrollment No. Unlocked Successfully";
        public static String Block_Arrangment_is_Pending_for_Selected_Exam = "Block Arrangment is Pending for Selected Exam.";
        public static String Select_at_least_one_Paper_Setter = "Select at least one Paper Setter";
        public static String Paper_Selected_successfully = "Paper Selected successfully";
        public static String Please_Select_at_Least_one_Subject = "Please Select at Least one Subject";
        public static String Curriculum_Wise_Subject_Updated_Successfully = "Curriculum Wise Subject Updated Successfully.";
        public static String No_subject_found_as_per_selected_criteria = "No subject found as per selected criteria.";
        public static String You_can_not_change_Absentee_of_selected_exam_as_result_of_exam_is_generated = "You can not change Absentee of selected exam as result of exam is generated.";
        public static String Assessment_Coordinator_Examiner_Assigned_Successfully = "Assessment Coordinator Examiner Assigned Successfully";
        public static String RPC_Result_Updated_Successfully = "RPC Result Updated Successfully";
        public static String Mark_Updated_Successfull_for_Selected_Subject = "Mark Updated Successfully for Selected Subject";
        public static String No_such_Registration_No_found = "No such Person (Registration No / Name) found";
        public static String No_Pending_Fees_found_as_per_selected_Criteria = "No Pending Fees found as per selected Criteria.";
        public static String Scholarship_Amount_Updated_Successfully = "Scholarship Amount Updated Successfully";
        public static String TripMemo_Locked_Successfully = "Trip Memo Locked Successfully.";
        public static String VoucherLocked = "Voucher is Locked. Hence you can not change.";
        public static string NoRecordInsertedStudent(string Name)
        {
            return "You have not entered any " + Name;
        }

        #region Time Table

        public static String Attendance_Duration_Over = "Attendance is locked. <i class=\"fa fa-lock\"></i>";
        public static String TimeTable_Template_Locked = "Timetable Template is locked. <i class=\"fa fa-lock\"></i>";
        public static String TimeTable_Template_Not_Locked = "Timetable Template is not locked, Please lock Timetable Template.";
        public static String TimeTable_Locked = "Timetable is locked";
        public static String TimeTable_Not_Locked = "Timetable is not locked";
        public static String TimeTable_Not_Locked_Attendance_NotFill = "Timetable is not locked. You Can not fill Attendance.";
        public static String Student_RollNo_Not_Locked = "Student Roll No Not Locked.";
        public static String Locked = "Locked Successfully";
        public static String UnLocked = "Unlocked Successfully";

        public static String TimeTable_WorkingDate_Not_Found = "Timetable Working Date Not Entered.";
        public static String TimeTable_TimetableTran_Not_Found = "Slots not Entered or Slots To Date Ended Or Term Ended.";
        public static String Attendance_Pending_Not_Download_Report = "There are some pending attendance in given criteria";
        public static String TimeTableInfoDays(String AllowedDays)
        {
            return @"<div class=""row"">
                                            <div class=""col-md-12 text-right"">
                                                <span class=""label label-danger"">Pending</span>
                                                <span class=""label label-success"">Filled</span>
                                                <span class=""label label-warning"">Altered</span>
                                                <span class=""label label-default"">Future</span>
                                                <span class=""label label-info""><i class=""fa fa-lock""></i> Attendance will be locked in " + AllowedDays + @" Days. </span>
                                            </div>
                                        </div><br />";
        }
        #endregion Time Table

        #region Hostel

        public static String Person_Not_Allowed_Gender_Not_Match(String Gender)
        {
            return Gender + " not allowed in this hostel.";
        }

        public static String Hostel_Pending_Outstanding = "Outstanding Pending : Registration can not left.";
        public static String Bed_InterChange_Successfully = "Bed InterChange Successfully.";
        public static String Another_Bed_Is_Selected = "Another Bed is Selected";
        #endregion Hostel
    }
}