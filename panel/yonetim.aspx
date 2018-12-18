<%@ Page Title="KTÜ Staj Programı" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="yonetim.aspx.cs" Inherits="panel_yonetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<%--    <script>
    function checkBoxes(checkedOne, checkBox) {
        checkedOne.forEach(function (element) {
            var arrayElement = document.getElementById(element);
            //dvPassport.style.display = checkBox.checked ? "block" : "none";
            if (checkBox.checked) {
                if (element == "DropDownList1" || element == "DropDownList2" || element == "DropDownList3")
                    arrayElement.style.display = "none";
                else
                    arrayElement.style.display = "block";


            }
            else {
                if (element == "DropDownList1" || element == "DropDownList2" || element == "DropDownList3")
                    arrayElement.style.display = "block";
                else
                    arrayElement.style.display = "none";
            }
        });
    }
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inbox-head">
        <h3><asp:Label ID="baslik" runat="server" Text="Label"></asp:Label></h3>
        <form action="#" class="pull-right position">
            <div class="input-append">
                <input type="text" id="searcher" class="sr-input" placeholder="Öğrenci Ara">
                <button class="btn sr-btn" type="button"><i class="fa fa-search"></i></button>
            </div>
        </form>
    </div>
    <div class="inbox-body">
        <asp:PlaceHolder ID="PlaceHoldericerik" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>

