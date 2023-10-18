Public Class stndrgsform
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim form As New STDRGSFRM.frmmst

        Divform.InnerHtml = form.fnFormDesign
    End Sub

End Class