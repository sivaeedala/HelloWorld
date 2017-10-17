<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!--Validation-->
	   <script> 
             $(document).ready(function () {
             for (i = 1; i < 6; i++)
             {
                 if (i != 1) {
                     $('#' + i).removeClass('active');
                 }
                 else {
                     $('#' + 1).addClass('active');
                 }
             }
         });
    </script>

</asp:Content>

