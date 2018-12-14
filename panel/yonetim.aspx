<%@ Page Title="KTÜ Staj Programı" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="yonetim.aspx.cs" Inherits="panel_yonetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <link rel="stylesheet" type="text/css" href="/css/panel.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <%--<script src="/js/jquery/jquery-1.11.1.min.js"></script>--%>
    <script src="/js/jquery/jquery-3.3.1.min.js"></script>
    <script src="/js/jqueryui/jquery-ui.js"></script>
    <script src="/js/wordcounter.js"></script>
    
    <%-- Bu Alan Gereklidir Bölümü İçin --%>
    <script src="/js/require.js"></script>
    <script src="/js/jquery.validate.min.js"></script>
    <script src="/js/jquery.maskedinput.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:PlaceHolder ID="PlaceHoldericerik" runat="server"></asp:PlaceHolder>
</asp:Content>

