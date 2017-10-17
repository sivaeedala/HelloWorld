<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%--  <h2><%: Title %>.</h2>--%>
    <h3>Your contact page</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">Phone:</abbr>425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>

    <!--Validation-->
	   <script> 
             $(document).ready(function () {
             for (i = 1; i < 6; i++)
             {
                 if (i != 5) {
                     $('#' + i).removeClass('active');
                 }
                 else {
                     $('#' + 5).addClass('active');
                 }
             }
         });
    </script>

</asp:Content>

