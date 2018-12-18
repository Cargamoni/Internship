<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="mulakat.aspx.cs" Inherits="panel_mulakat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    
<div class="mail-option">
                                <div class="form-group col-lg-12">
                                <asp:Label ID="Label2" runat="server" Text="Staj Başlangıç Tarihi"></asp:Label>
                                <div class="input-group date datepicker" data-provide="datepicker">
                                    <input id="baslangicTarihi" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>

    </div>

    <script>

    </script>
</asp:Content>

