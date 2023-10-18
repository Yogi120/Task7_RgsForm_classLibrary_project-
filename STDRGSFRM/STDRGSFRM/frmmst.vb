Imports Microsoft.SqlServer.Server

Public Class frmmst
    Public Function fnFormDesign() As String
        Dim sAsp As String = ""

        sAsp += "<h1 style='margin-bottom:50px; text-align:center'>" & "Student Registration Form" & "</h1>"

        sAsp += "<table width: 100%>"

        sAsp += "<tr>"
        sAsp += "<td id='name'>" & "Name: "
        sAsp +=
            "<input type='text' id='Fnme' placeholder='First Name'/>" &
            "<input type='text' id='Mnme' placeholder='Middle Name'/>" &
            "<input type='text' id='Lnme' placeholder='Last Name'/>"
        sAsp += "</td>"
        sAsp += "</tr>"

        sAsp += "<tr>"
        sAsp += "<td>" & "Date of Birth: " & "<input type='date' id='dtdob' onchange='SetAgeLimit()'/>" & "</td>"
        sAsp += "</tr>"

        sAsp += "<tr>"
        sAsp += "<td>" & "Gender: "
        sAsp +=
            "<input type='radio' id='rdMale' name='rdGender' value='Male' checked='checked' onchange='Enablebutton()'/> Male" &
            "<input type='radio' id='rdFemale' name='rdGender' value='Female' onchange='Enablebutton()'/> Female" &
            "<input type='radio' id='rdOther' name='rdGender' value='Other' onchange='Disablebutton()'/> Other"
        sAsp += "</td>"
        sAsp += "</tr>" & vbCrLf

        sAsp += "<tr>"
        sAsp += "<td>" & "Mobile Number: " & "<input type='text' id='phone' onchange='MobileValidation()'/>" & "</td>"
        sAsp += "</tr>" & vbCrLf

        sAsp += "<tr>"
        sAsp += "<td>" & "Email_id: " & "<input type='email' id='email' onchange='EmailValidation()'/>" & "</td>"
        sAsp += "</tr>"

        sAsp += "<tr>"
        sAsp += "<td>" & "Course: " & "<input type='text' id='txtCourse'/>" & "</td>"
        sAsp += "</tr>"
        sAsp += "<br>" & "</br>"

        sAsp += "</table>"

        sAsp += "<input type='button' id='btnReset' value='Reset' style='margin-top:40px; margin-right:100px' onclick='ResetData()'/>" & vbCrLf
        sAsp += "<input type='button' id='btnSave' name='BtnSave' value='Submit' onclick='fnValidateData(); fnAddRow(); DisplayClear()' />" & vbCrLf

        sAsp += "<table style='display: none; margin-top: 20px; margin-left: 5px; border: 2px solid; width: 100%; text-align: center;' id='tbldata' >"
        sAsp += "<tr style = 'border: 2px solid' >"
        sAsp += "<th>Sr.No.</th>" &
                    "<th> Name </th>" &
                    "<th>Date Of Birth</th>" &
                    "<th> Gender </th>" &
                    "<th>Mobile Number.</th>" &
                    "<th> Email_id </th>" &
                    "<th> Course Name </th>" & vbCrLf
        sAsp += "</tr>" & vbCrLf
        sAsp += "</table>"


        sAsp += vbCrLf & fnPageJS()

        Return sAsp
    End Function


    Private Function fnPageJS() As String

        Dim sPd As String = ""

        sPd += "<script type='text/javascript'>" & vbCrLf
        sPd += "var serialNumber = 1" & vbCrLf
        sPd += "var is_valid = false" & vbCrLf

        sPd += fnReset() & vbCrLf
        sPd += fnValidate() & vbCrLf
        sPd += fnMobilDuplication() & vbCrLf
        sPd += fnEmailDuplication() & vbCrLf
        sPd += fnSetAge() & vbCrLf
        sPd += fnAddDataRow() & vbCrLf
        sPd += fnDisplay_Clear() & vbCrLf
        sPd += fnDisabelSave() & vbCrLf
        sPd += fnEnableSave()

        sPd += "</script>" & vbCrLf

        fnPageJS = sPd

    End Function

    Private Function fnValidate() As String

        Dim sJs As String = ""

        sJs += "function fnValidateData()  "
        sJs += "{" & vbCrLf

        sJs += "var Fname = document.getElementById('Fnme').value" & vbCrLf
        sJs += "var Mname = document.getElementById('Mnme').value" & vbCrLf
        sJs += "var Lname = document.getElementById('Lnme').value" & vbCrLf
        sJs += "var DOB = document.getElementById('dtdob').value" & vbCrLf
        sJs += "var Mobile = document.getElementById('phone').value" & vbCrLf
        sJs += "var email = document.getElementById('email').value" & vbCrLf
        sJs += "var Course = document.getElementById('txtCourse').value" & vbCrLf

        sJs += "var Error_message = ''" & vbCrLf

        sJs += "if (!Fname) {
                        Error_message += 'Kindly enter first name\n' 
                            is_valid = false }" & vbCrLf
        sJs += "if (!Mname) {
                        Error_message +='Kindly enter middle name\n' 
                            is_valid = false }" & vbCrLf
        sJs += "if (!Lname) {
                        Error_message += 'Kindly enter last name\n' 
                            is_valid = false }" & vbCrLf
        sJs += "if (!DOB) {
                        Error_message += 'kindly enter Date of Birth\n' 
                            is_valid = false }" & vbCrLf
        sJs += "if (!Mobile) {
                        Error_message += 'kindly enter the Mobile Number\n'
                            is_valid = false }" & vbCrLf
        sJs += "if (!email) {
                        Error_message += 'kindly entere the email id\n' 
                            is_valid = false }" & vbCrLf
        sJs += "if (!Course) {
                        Error_message += 'Kindly enter the course name\n' 
                            is_valid = false }" & vbCrLf

        sJs += "if (Error_message != '') 
                    {alert(Error_message) }
                else if (Error_message == '') 
                    {is_valid = true }" & vbCrLf

        sJs += "}" & vbCrLf



        fnValidate = sJs

    End Function

    Private Function fnAddDataRow()
        Dim sJs As String = ""


        sJs += " function fnAddRow()"
        sJs += "{" & vbCrLf
        sJs += "if (is_valid == true)" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "var table = document.getElementById('tbldata')" & vbCrLf
        sJs += "var rowcount = table.rows.length" & vbCrLf
        sJs += "var row = table.insertRow(rowcount)" & vbCrLf

        sJs += "var tdSrno = row.insertCell(0)" & vbCrLf
        sJs += "tdSrno.innerText = serialNumber " & vbCrLf
        sJs += "serialNumber += 1" & vbCrLf

        sJs += "var tdName = row.insertCell(1)" & vbCrLf
        sJs += "var firstName = document.getElementById('Fnme').value" & vbCrLf
        sJs += "var middleName = document.getElementById('Mnme').value" & vbCrLf
        sJs += "var lastName = document.getElementById('Lnme').value" & vbCrLf
        sJs += "tdName.innerText = firstName + ' ' + middleName + ' ' + lastName" & vbCrLf

        sJs += "var tdDOB = row.insertCell(2)" & vbCrLf
        sJs += "var dob = document.getElementById('dtdob').value" & vbCrLf
        sJs += "tdDOB.innerText = dob" & vbCrLf

        sJs += "var tdGender = row.insertCell(3)" & vbCrLf

        sJs += "var gender = document.querySelector('input[name=""rdGender""]:checked')" & vbCrLf
        sJs += "tdGender.innerText = gender.value" & vbCrLf

        sJs += "var tdMobile = row.insertCell(4)" & vbCrLf
        sJs += "var mobile = document.getElementById('phone').value" & vbCrLf
        sJs += "tdMobile.innerText = mobile" & vbCrLf

        sJs += "var tdEmail = row.insertCell(5)" & vbCrLf
        sJs += "var email = document.getElementById('email').value" & vbCrLf
        sJs += "tdEmail.innerText = email" & vbCrLf

        sJs += "var tdCourse = row.insertCell(6)" & vbCrLf
        sJs += "var course = document.getElementById('txtCourse').value" & vbCrLf
        sJs += "tdCourse.innerText = course" & vbCrLf
        sJs += "}" & vbCrLf

        sJs += "}" & vbCrLf

        fnAddDataRow = sJs

    End Function

    Private Function fnDisplay_Clear()
        Dim sJs As String = ""

        sJs += "function DisplayClear()"
        sJs += "{" & vbCrLf
        sJs += "if (is_valid == true)" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "alert('data added sucessfully !' )" & vbCrLf

        sJs += "document.getElementById('tbldata').style.display = ''" & vbCrLf
        sJs += "document.getElementById('Fnme').value = ''" & vbCrLf
        sJs += "document.getElementById('Mnme').value = ''" & vbCrLf
        sJs += "document.getElementById('Lnme').value = ''" & vbCrLf
        sJs += "document.getElementById('dtdob').value = ''" & vbCrLf
        sJs += "document.getElementById('phone').value = ''" & vbCrLf
        sJs += "document.getElementById('email').value = ''" & vbCrLf
        sJs += "document.getElementById('txtCourse').value = ''" & vbCrLf
        ' sJs += "document.getElementById('tblForm').reset()" & vbCrLf
        sJs += "}" & vbCrLf

        sJs += "}" & vbCrLf
        fnDisplay_Clear = sJs

    End Function

    Private Function fnReset()
        Dim sJs As String = ""

        sJs += "function ResetData()" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "document.getElementById('Fnme').value = ''" & vbCrLf
        sJs += "document.getElementById('Mnme').value = ''" & vbCrLf
        sJs += "document.getElementById('Lnme').value = ''" & vbCrLf
        sJs += "document.getElementById('dtdob').value = ''" & vbCrLf
        sJs += "document.getElementById('phone').value = ''" & vbCrLf
        sJs += "document.getElementById('email').value = ''" & vbCrLf
        sJs += "document.getElementById('txtCourse').value = ''" & vbCrLf
        sJs += "document.getElementById('rdMale').checked = true" & vbCrLf
        sJs += "document.getElementById('btnSave').disabled = false" & vbCrLf
        sJs += "}" & vbCrLf
        fnReset = sJs

    End Function

    Private Function fnMobilDuplication()
        Dim sJs As String = ""

        sJs += "function MobileValidation()" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "var mobile = document.getElementById('phone').value.trim()" & vbCrLf
        sJs += "var table = document.getElementById('tbldata')" & vbCrLf
        sJs += "for (var i=0; i<table.rows.length; i++)" & vbCrLf
        sJs += "{" & vbCrLf

        sJs += "var mobileCell = table.rows[i].cells[4]" & vbCrLf
        sJs += "if(mobileCell.innerText.trim() == mobile)" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "alert('Mobile number is already exist !')" & vbCrLf
        sJs += "is_valid = false" & vbCrLf
        sJs += "document.getElementById('phone').value = ''" & vbCrLf
        sJs += "document.getElementById('phone').focus()" & vbCrLf
        sJs += "return" & vbCrLf
        sJs += "}" & vbCrLf
        sJs += "}" & vbCrLf
        sJs += "}"

        fnMobilDuplication = sJs
    End Function

    Private Function fnEmailDuplication()
        Dim sJs As String = ""

        sJs += "function EmailValidation()" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "var email = document.getElementById('email').value.trim()" & vbCrLf
        sJs += "var table = document.getElementById('tbldata')" & vbCrLf
        sJs += "for (var i=0; i<table.rows.length; i++)" & vbCrLf
        sJs += "{" & vbCrLf

        sJs += "var emailCell = table.rows[i].cells[5]" & vbCrLf
        sJs += "if(emailCell.innerText.trim() == email)" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "alert('Email id is already exist !')" & vbCrLf
        sJs += "is_valid = false" & vbCrLf
        sJs += "document.getElementById('email').value = ''" & vbCrLf
        sJs += "document.getElementById('email').focus()" & vbCrLf
        sJs += "return" & vbCrLf
        sJs += "}" & vbCrLf
        sJs += "}" & vbCrLf
        sJs += "}"

        fnEmailDuplication = sJs
    End Function

    Private Function fnDisabelSave()
        Dim sJs As String = ""
        sJs += "function Disablebutton()"
        sJs += "{" & vbCrLf
        sJs += "if(document.getElementById('rdOther').checked == true)"
        sJs += "{" & vbCrLf
        sJs += "document.getElementById('btnSave').disabled = true"
        sJs += "}" & vbCrLf
        sJs += "}" & vbCrLf

        fnDisabelSave = sJs

    End Function

    Private Function fnEnableSave()
        Dim sJs As String = ""
        sJs += "function Enablebutton()"
        sJs += "{" & vbCrLf
        sJs += "if(document.getElementById('rdOther').checked == false){
                        document.getElementById('btnSave').disabled = false}"
        sJs += "}" & vbCrLf

        fnEnableSave = sJs

    End Function


    Private Function fnSetAge()
        Dim sJs As String = ""

        sJs += "function SetAgeLimit()" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "var todayDt = new Date()" & vbCrLf
        sJs += "var UserDt = document.getElementById('dtdob')" & vbCrLf
        sJs += "newdt = new Date(UserDt.value)" & vbCrLf
        sJs += "if(todayDt.getFullYear()-newdt.getFullYear() < 18)" & vbCrLf
        sJs += "{" & vbCrLf
        sJs += "alert('Minimum age should be 18')" & vbCrLf
        sJs += "UserDt.value = ''" & vbCrLf
        ' sJs += "UserDt = ''" & vbCrLf
        sJs += "}" & vbCrLf
        sJs += "}"

        fnSetAge = sJs

    End Function
End Class
