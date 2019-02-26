<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uyeler.ascx.cs" Inherits="panel_uyeler" %>

<div class="mail-option">
    <div class="chk-all">
        <input type="checkbox" class="mail-checkbox mail-group-checkbox">
        <div class="btn-group">
            <a data-toggle="dropdown" href="#" class="btn mini all" aria-expanded="false">All
                                        
                <i class="fa fa-angle-down "></i>
            </a>
            <ul class="dropdown-menu">
                <li><a href="#">None</a></li>
                <li><a href="#">Read</a></li>
                <li><a href="#">Unread</a></li>
            </ul>
        </div>
    </div>

    <div class="btn-group">
        <a data-original-title="Refresh" data-placement="top" data-toggle="dropdown" href="#" class="btn mini tooltips">
            <i class=" fa fa-refresh"></i>
        </a>
    </div>
    <div class="btn-group hidden-phone">
        <a data-toggle="dropdown" href="#" class="btn mini blue" aria-expanded="false">More
                                    
                                <i class="fa fa-angle-down "></i>
        </a>
        <ul class="dropdown-menu">
            <li><a href="#"><i class="fa fa-pencil"></i>Mark as Read</a></li>
            <li><a href="#"><i class="fa fa-ban"></i>Spam</a></li>
            <li class="divider"></li>
            <li><a href="#"><i class="fa fa-trash-o"></i>Delete</a></li>
        </ul>
    </div>
    <div class="btn-group">
        <a data-toggle="dropdown" href="#" class="btn mini blue">Move to
                                    
                                <i class="fa fa-angle-down "></i>
        </a>
        <ul class="dropdown-menu">
            <li><a href="#"><i class="fa fa-pencil"></i>Mark as Read</a></li>
            <li><a href="#"><i class="fa fa-ban"></i>Spam</a></li>
            <li class="divider"></li>
            <li><a href="#"><i class="fa fa-trash-o"></i>Delete</a></li>
        </ul>
    </div>

    <ul class="unstyled inbox-pagination">
        <button type="button" class="btn mini btn-primary" data-toggle="modal" data-target="#myModal">Staj Ekle</button>
        <!-- Modal -->
        <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade" style="display: none;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">×</button>
                        <h4 class="modal-title">Staj Ekle</h4>
                    </div>
                    <div class="modal-body">
                        <form name="stajForm" id="stajForm" runat="server">
                            <div class="form-group col-lg-12 control-label">
                                <asp:TextBox ID="ogrenciNo" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                            </div>

                            <%-- Konu --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:Label ID="konuLabel" runat="server" Text="Bir Konu Seçiniz veya Ekleyiniz"></asp:Label>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control btn-block dropdown"></asp:DropDownList>
                                <asp:TextBox ID="yeniKonu" runat="server" CssClass="form-control input-lg countedfor50"></asp:TextBox>
                                <asp:Label ID="sayici" runat="server"></asp:Label>
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="False" CssClass="checkbox col-lg-10"
                                    onclick="var args = ['yeniKonu', 'sayici', 'DropDownList1']; checkBoxes(args,this);"></asp:CheckBox>
                            </div>

                            <%-- İşyeri  --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:Label ID="isyeriLabel" runat="server" Text="Bir İşyeri Seçiniz veya Ekleyiniz"></asp:Label>
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control btn-block dropdown"></asp:DropDownList>
                                <asp:TextBox ID="yeniIsyeri" runat="server" CssClass="form-control input-lg countedfor50"></asp:TextBox>
                                <asp:Label ID="sayici2" runat="server"></asp:Label>
                                <asp:TextBox ID="yeniIsyeriAdres" runat="server" CssClass="form-control input-lg countedfor50"></asp:TextBox>
                                <asp:TextBox ID="yeniIsyeriIletisim" runat="server" CssClass="form-control input-lg countedfor50"></asp:TextBox>
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="False" CssClass="checkbox col-lg-10"
                                    onclick="var args = ['yeniIsyeri', 'sayici2', 'DropDownList2', 'yeniIsyeriAdres', 'yeniIsyeriIletisim']; checkBoxes(args,this);"></asp:CheckBox>
                            </div>

                            <%-- Başlangıç ve Bitiş --%>
                            <div class="form-group col-lg-12">
                                <asp:Label ID="Label2" runat="server" Text="Staj Başlangıç Tarihi"></asp:Label>
                                <div class="input-group date datepicker" data-provide="datepicker">
                                    <input id="baslangicTarihi" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>

                            <div class="form-group col-lg-12">
                                <asp:Label ID="Label3" runat="server" Text="Staj Bitiş Tarihi"></asp:Label>
                                <div class="input-group date datepicker2" data-provide="datepicker">
                                    <input id="bitisTarihi" type="text" class="form-control" runat="server"><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>

                            <script type="text/javascript">
                                $('.datepicker').datepicker({
                                    format: 'dd/mm/yyyy'
                                });
                                $('.datepicker2').datepicker({
                                    format: 'dd/mm/yyyy'
                                });
                            </script>

                            <%-- Toplam Gün --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:TextBox ID="toplam_gun" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                            </div>

                            <%-- Kabul Edilen --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:TextBox ID="kabulEdilen" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                            </div>

                            <%-- Değerlendirme --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:TextBox ID="degerlendirme" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                            </div>

                            <%-- Sınıf --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:TextBox ID="sinif" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                            </div>

                            <%-- Departman --%>
                            <div class="form-group col-lg-12 control-label">
                                <asp:Label ID="Label1" runat="server" Text="Bir Departman Seçiniz veya Ekleyiniz"></asp:Label>
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control btn-block dropdown"></asp:DropDownList>
                                <asp:TextBox ID="yeniDepartman" runat="server" CssClass="form-control input-lg countedfor50"></asp:TextBox>
                                <asp:Label ID="sayici3" runat="server"></asp:Label>
                                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="False" CssClass="checkbox col-lg-10"
                                    onclick="var args = ['yeniDepartman', 'sayici3', 'DropDownList3']; checkBoxes(args,this);"></asp:CheckBox>
                            </div>

                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Stajı Ekle" type="submit" value="Stajı Ekle" class="btn btn-lg btn-info btn-block" />
                            <%--<button type="submit" runat="server" onclick="Button1_Click" id="Button1"  class="btn btn-lg btn-info btn-block">Staj Ekle</button>--%>
                        </form>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </ul>
    <script>
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
</script>
</div>

<table class="table table-inbox table-hover">
    <tbody>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </tbody>
</table>
