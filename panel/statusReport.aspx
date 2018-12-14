<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="statusReport.aspx.cs" Inherits="panel_statusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="col-xs-12 col-sm-8 col-md-9" style="padding-top: 70px;">
        <div class="col-md-20">
            <p class="col-md-12">
                <asp:Label ID="imageControl" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#336600" Text="Label"></asp:Label>
            </p>
        </div>
        <div class="col-md-20" style="float: right">
            <asp:Button class="btn btn-primary" ID="Button1" runat="server" OnClick="Button1_Click" Text="Siteyi Görüntüle" Width="189px" />
        </div>
    </div>
</asp:Content>

