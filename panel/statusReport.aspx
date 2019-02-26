<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="statusReport.aspx.cs" Inherits="panel_statusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="inbox-body">
        <div class="col-xs-12 col-sm-8 col-md-9" style="padding-top: 70px;">
            <div class="col-md-20">
                <p class="col-md-12">
                    <asp:Label ID="imageControl" runat="server"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#336600" Text="Label"></asp:Label>
                </p>
            </div>
            <div class="col-md-20" style="float: right">
                <%--<asp:Button class="btn btn-primary" ID="Button1" runat="server" OnClick="Button1_Click" Text="Siteyi Görüntüle" Width="189px" />--%>
            </div>
        </div>
    </div>

</asp:Content>

