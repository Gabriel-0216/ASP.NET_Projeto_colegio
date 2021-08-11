﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarDisciplinasPorCurso.aspx.cs" Inherits="ProjetoColegio.Colegio.MostrarDisciplinasPorCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblNomeDisciplina" runat="server" Text="Nome da disciplina:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxNomeDisciplina" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNomeDisciplina" Style="color: red;" ErrorMessage="* Digite o nome da disciplina."></asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:Label ID="lblNumeroSemestre" runat="server" Text="Número do semestre:"></asp:Label>
                </td>

                <td>
                     <asp:TextBox ID="tbxNumeroSemestre" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxNumeroSemestre" Style="color: red;" ErrorMessage="* Digite o número do semestre da disciplina."></asp:RequiredFieldValidator>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnAdicionarDisicplina" runat="server" OnClick="BtnAdicionarDisciplina_click" Text="Adicionar"/>
                </td>
            </tr>
        </table>
    </div>


    <br />

    <div>
       
        <br />

     <asp:GridView ID="gvGerenciamentoDisciplinas"  runat="server" Width="100%" AutoGenerateColumns="False" Font-Size="14px" CellPadding="4"
ForeColor="#333333" GridLines="None" >
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdDisciplina"  runat="server" Style="width: 100%" Text="Código Disciplina"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdDisciplina" runat="server" Style="width: 100%" Text='<%#Eval("CodigoDisciplina") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50PX" />
                    <ItemStyle HorizontalAlign="Left" />

                </asp:TemplateField>
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdCurso" runat="server" Style="width: 100%" Text="Código Curso">
                        </asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdCurso" runat="server" Style="width: 100%" Text='<%#Eval("CodigoCurso")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                 <asp:TemplateField>
                     <HeaderTemplate>
                         <asp:Label ID="lblTextoNomeDisciplina" runat="server" Style="width: 100%" Text="Nome"></asp:Label>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblNomeDisciplina" runat="server" Style="width:100%" Text='<%#Eval("Nome") %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Left" Width="400px" />
                     <ItemStyle HorizontalAlign="Left" />
                 </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNumeroSemestre" runat="server" Style="width:100%" Text="Número do semestre:"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:label ID="lblNumeroSemestre" runat="server" Style="width: 100%" Text='<%#Eval("NumeroSemestre")%>'></asp:label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="400px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

            </Columns>



        </asp:GridView></div>
</asp:Content>
