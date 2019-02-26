<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="mulakat.aspx.cs" Inherits="panel_mulakat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/css/bootstrap-timepicker.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/js/bootstrap-timepicker.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <h3>Tarih</h3>
            <div class="input-group date datepicker" data-provide="datepicker">
                <input id="baslangicTarihi" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
            </div>
        </div>
        <div class="form-group col-lg-12">
            <h3>Saat</h3>
            <div class="input-group bootstrap-timepicker timepicker">
                <input id="baslangicSaati" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
            </div>
        </div>

        <div class="form-group col-lg-12">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mülakatı Ekle" type="submit" value="Stajı Ekle" class="btn btn-md btn-info btn-block" />
        </div>
    </form>

    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd/mm/yyyy'
        });

        $('#timepicker1').timepicker();

    </script>
</asp:Content>

