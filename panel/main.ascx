<%@ Control Language="C#" AutoEventWireup="true" CodeFile="main.ascx.cs" Inherits="panel_main" %>

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


<%--            <ul class="unstyled inbox-pagination">
                <li><span>--%><%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%><%--</span></li>
                <li>--%>
                    <%--<asp:LinkButton ID="Button1" runat="server"><i class="fa fa-angle-left  pagination-left"></i></asp:LinkButton>--%>
                    <%--<a class="np-btn" id="Button1" href="yonetim.aspx?user=topics&sayfa=<%=(Convert.ToInt32(Sayfa)-1).ToString()%>" runat="server"><i class="fa fa-angle-left  pagination-left"></i></a>--%>
<%--                </li>
                <li>--%>
                    <%--<asp:LinkButton ID="Button2" runat="server"><i class="fa fa-angle-left  pagination-right"></i></asp:LinkButton>--%>
                    <%--<a class="np-btn" id="Button2" href="yonetim.aspx?user=topics&sayfa=<%=(Convert.ToInt32(Sayfa)+1).ToString()%>" runat="server"><i class="fa fa-angle-right pagination-right"></i></a>--%>
<%--                </li>
            </ul>--%>
        </div>

<table class="table table-inbox table-hover">
                        <tbody>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </tbody>
</table>


                            <script src="../js/jquery/jquery-1.11.1.min.js"></script>
                            <script>
                                $(document).ready(function () {
                                    function Contains(text_one, text_two) {
                                        if (text_one.indexOf(text_two) != -1)
                                            return true;
                                    }
                                    $("#searcher").keyup(function () {
                                        var searchText = $("#searcher").val().toLocaleLowerCase();
                                        $(".searchThese").each(function () {
                                            if(!Contains($(this).text().toLocaleLowerCase(),searchText))
                                            {
                                                $(this).hide();
                                            }
                                            else
                                            {
                                                $(this).show();
                                            }
                                        });
                                    });

                                });
                            </script>