<%@ Page Title="Gerenciamento Alunos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoAlunos.aspx.cs" Inherits="ProjetoColegio.Colegio.GerenciamentoAlunos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Gerenciamento de alunos</h2>
        <table>
            <tr style="display: grid">

                <td>
                     <asp:Label ID="lblNomeAluno" runat="server" Text="Nome:"></asp:Label>
                </td>

                <td>
                    <asp:TextBox ID="tbxNomeAluno" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxNomeAluno" Style="color: red;" ErrorMessage="* Digite o nome do ALUNO."></asp:RequiredFieldValidator>
                </td>

                <td>
                     <asp:Label ID="lblDataNascimento" runat="server">Data de nascimento</asp:Label>
                </td>

                <td>
                    <asp:TextBox ID="tbxDataNascimento" runat="server"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </td>

                <td>
                     <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxNomeAluno" Style="color: red;" ErrorMessage="* Digite o email do ALUNO."></asp:RequiredFieldValidator>
                </td>


                <td>
                    <asp:Button runat="server" ID="btnAdicionarAluno" Text="Adicionar" OnClick="BtnNovoAluno_click" />
                </td>
            </tr>


        </table>
        
    
        
       
        <br />

        
       

       


    </div>

    <br />
    <br />

    <div>
        <asp:GridView runat="server" ID="gvGerenciamentoAlunos" Width="100%" AutoGenerateColumns="false" Font-Size="14px" CellPadding="4" ForeColor="#3331" GridLines="None" OnRowCommand="gvGerenciamentoAlunos_RowCommand"> 
            
            
            
            
            <Columns>
                <asp:TemplateField Visible="false">
 <EditItemTemplate>
 <asp:Label ID="lblEditCodigoAluno" runat="server" Text='<%# Eval("CodigoAluno") %>'></asp:Label>
 </EditItemTemplate>
 <HeaderTemplate>
 <asp:Label ID="lblTextoCodigoAluno" runat="server" Style="width: 100%" Text="ID"></asp:Label>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblIdAluno" runat="server" Style="text-align: center;" Text='<%# Eval("CodigoAluno") %>'></asp:Label>
 </ItemTemplate>
 <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
 <ItemStyle HorizontalAlign="Center"></ItemStyle>
 
                </asp:TemplateField>

                 <asp:TemplateField>
 
                <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeAluno" runat="server" Style="text-align: center;" Text="Nome"></asp:Label>
                </HeaderTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lblNomeAluno" runat="server" Style="text-align: left;" Text='<%# Eval("Nome") %>'></asp:Label>
                    </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Left" Width="150px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>



                 <asp:TemplateField>
                <HeaderTemplate>
                        <asp:Label ID="lblNumeroMatricula" runat="server" Style="text-align: center;" Text="Número de matricula:"></asp:Label>
                </HeaderTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lblTxtNumeroMatricula" runat="server" Style="text-align: left;" Text='<%# Eval("NumeroMatricula") %>'></asp:Label>
                    </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Left" Width="150px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>




                 <asp:TemplateField>
                <HeaderTemplate>
                        <asp:Label ID="lblDataNascimento" runat="server" Style="text-align: center;" Text="Data de nascimento:"></asp:Label>
                </HeaderTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lblTextDataNascimento" runat="server" Style="text-align: left;" Text='<%# Eval("DataNascimento") %>'></asp:Label>
                    </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Left" Width="150px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>




                  <asp:TemplateField>
                <HeaderTemplate>
                        <asp:Label ID="lblEmail" runat="server" Style="text-align: center;" Text="Email:"></asp:Label>
                </HeaderTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lbltxtEmail" runat="server" Style="text-align: left;" Text='<%# Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Left" Width="150px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>




               <asp:TemplateField>
                   <ItemTemplate>
                    <asp:Button ID="btnMostrarDisciplinas" runat="server" CssClass="btn btn-primary" Text="Disciplinas" CommandName="MostrarDisciplinas"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />&nbsp;
                      
                       <asp:Button ID="btnMostrarCursos" runat="server" CssClass="btn btn-success" Text="Mostrar Cursos" CommandName="MostrarCursos" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                            />&nbsp;


                       </ItemTemplate>


                       </asp:TemplateField>

             


            </Columns>



        </asp:GridView>
    </div>



    </div>
</asp:Content>
