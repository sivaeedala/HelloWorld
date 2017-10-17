<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <!--Validation-->
	   <script> 
             $(document).ready(function () {
             for (i = 1; i < 6; i++)
             {
                 if (i != 2) {
                     $('#' + i).removeClass('active');
                 }
                 else {
                     $('#' + 2).addClass('active');
                 }
             }
         });
    </script>

</asp:Content>

