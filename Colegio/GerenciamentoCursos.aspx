<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoCursos.aspx.cs" Inherits="ProjetoColegio.Colegio.GerenciamentoCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>

        <h2>Lista de Cursos</h2>


        <asp:GridView ID="gvGerenciamentoCursos" runat="server" Width="100%" AutoGenerateColumns="false" Font-Size="14px" CellPadding="4" ForeColor="#00000" GridLines="None" OnRowCommand="gvGerenciamentoCursos_RowCommand">
            <Columns>
                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditCodigoCurso" runat="server" Text='<%#Eval("CodigoCurso")%>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoCodigoCurso" runat="server" Style="width: 100%" Text="ID"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCodigoCurso" runat="server" style="text-align: center;" Text='<%#Eval("CodigoCurso") %>'></asp:Label> 
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>


                <asp:TemplateField>
                     <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeCursoSOLEITURA" runat="server" Style="width: 100%" Text="Nome Curso"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeCurso" runat="server" style="text-align: center;" Text='<%#Eval("nome") %>'></asp:Label> 
                    </ItemTemplate>


                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoQUANTIDADESEMESTRES" runat="server" Style="width: 100%" Text="Quantidade de Semestres"></asp:Label>
                    </HeaderTemplate>
                       <ItemTemplate>
                        <asp:Label ID="lblQntdeSemestres" runat="server" style="text-align: center;" Text='<%#Eval("QuantidadeSemestres") %>'></asp:Label> 
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField>
                   <ItemTemplate>
                    <asp:Button ID="btnMostrarDisciplinas" runat="server" CssClass="btn btn-primary" Text="Disciplinas" CommandName="MostrarDisciplinas"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />&nbsp;

                       </ItemTemplate>



                       </asp:TemplateField>



            </Columns>
        </asp:GridView>


    </div>
</asp:Content>
