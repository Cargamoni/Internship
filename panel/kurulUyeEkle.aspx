<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="kurulUyeEkle.aspx.cs" Inherits="panel_kurulUyeEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link type="text/css" rel="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/css/bootstrap-timepicker.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/js/bootstrap-timepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="inbox-head">
        <h3>
            <asp:Label ID="baslik" runat="server" Text="Label"></asp:Label></h3>
        <form action="#" class="pull-right position">
            <div class="input-append">
                <input type="text" class="sr-input" placeholder="Öğrenci Ara">
                <button class="btn sr-btn" type="button"><i class="fa fa-search"></i></button>
            </div>
        </form>
    </div>

    <form class="mail-option" runat="server">
        <div class="form-group col-lg-12">
            <h3>Adi</h3>
            <div class="input-group date datepicker">
                <input id="uyeAd" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-user"></i></span>
            </div>
        </div>
        <div class="form-group col-lg-12">
            <h3>Soyadı</h3>
            <div class="input-group bootstrap-timepicker timepicker">
                <input id="uyeSoyad" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-user"></i></span>
            </div>
        </div>
                <div class="form-group col-lg-12">
            <h3>Unvan</h3>
            <div class="input-group date datepicker">
                <input id="uyeUnvan" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-user"></i></span>
            </div>
        </div>
        <div class="form-group col-lg-12">
            <h3>Yetki</h3>
            <div class="input-group bootstrap-timepicker timepicker">
                <input id="uyeYetki" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-user"></i></span>
            </div>
        </div>
                <div class="form-group col-lg-12">
            <h3>Parola</h3>
            <div class="input-group bootstrap-timepicker timepicker">
                <input id="uyeParola" type="password" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-user"></i></span>
            </div>
        </div>

        <div class="form-group col-lg-12">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Üyeyi Ekle" type="submit" value="Üyeyi Ekle" class="btn btn-md btn-info btn-block" />
        </div>
    </form>
</asp:Content>

