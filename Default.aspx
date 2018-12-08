<%@ Page EnableEventValidation="false" Title="KTÜ - Staj Programı" Language="C#" MasterPageFile="~/internship.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="container">
            <div class="card card-container">
                <img id="profile-img" class="profile-img-card" src="images/ktulogo.png" />
                <p id="profile-name" class="profile-name-card"></p>
                <form class="form-signin" runat="server">
                    <span id="reauth-email" class="reauth-email"></span>
                    <asp:TextBox ID="uyeno" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:TextBox ID="uyeparola" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <%--<div id="remember" class="checkbox">
                    <label>
                        <input type="checkbox" value="remember-me"> Remember me
                    </label>
                    </div>--%>
                    <%--<button class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Giriş Yap</button>--%>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş Yap" type="submit" value="Kayıt Ol" class="btn btn-lg btn-primary btn-block btn-signin" />
                </form>
            </div>
            <!-- /card-container -->
        </div>
        <!-- /container -->
    </div>
    <asp:SqlDataSource ID="sqlDataSource1" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:InternshipConnection%>"
        SelectCommand="SELECT * FROM [kurul] WHERE (([uno] = uno) AND ([parola] = parola))">
        <SelectParameters>
            <asp:ControlParameter ControlID="uyeno" Name="uyeno" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="uyeparola" Name="uyeparola" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

