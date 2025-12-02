<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="waAgenda.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <table>
            <tbody>
                <tr>
                    <fielset>
                        <legend>Formulário</legend>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCpfCnpj" runat="server" BackColor="LightYellow" MaxLength="10" Tipo="Text" Width="100px" OnTextChanged="txtTpPessCoop_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList 
                                                            ID="ddlTipoPessoa" 
                                                            runat="server" 
                                                            AutoPostBack="true"
                                                            Width="120px"
                                                            OnSelectedIndexChanged="cboTpPessCoop_TextChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
    
                                                        <asp:Button 
                                                            ID="btnInserir" 
                                                            runat="server" 
                                                            Text="Inserir" 
                                                            OnClick="btnInserir_Click" />
                                                    </td>
                                                    <td>
    
                                                        <asp:Button 
                                                            ID="btnCancelar" 
                                                            runat="server" 
                                                            Text="Cancelar" 
                                                            OnClick="btnCancelar_Click" Enabled="false"/>
                                                    </td>
                                                 </tr>
                                            
                                            </table>
                                        
                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvCooperado" runat="server" AutoGenerateColumns="False" 
                                                                             OnRowCommand="gvCooperado_RowCommand" OnRowDeleting="gvCooperado_RowDeleting" Width="400px" EmptyDataText="Não há dados cadastrados">
                                                        <Columns>
                                                        <asp:BoundField DataField="CpfCnpj" HeaderText="CPF ou CNPJ" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TipoPessoa" HeaderText="Tipo de Pessoa" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:ButtonField CommandName="Alterar" Text="Alterar" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:CommandField DeleteText="Excluir" ShowDeleteButton="true" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        </asp:GridView>
                                                        <asp:Label ID="lblLinhaCooperado" runat="server" Visible="false" />
                                                                                                            </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </fielset>
                </tr>
                <tr style="text-align: center;">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Button 
                                        ID="btnConfirmar" 
                                        runat="server" 
                                        Text="Confirmar" 
                                         />
                                </td>
                                 <td>
                                     <asp:Button 
                                         ID="Button1" 
                                         runat="server" 
                                         Text="Voltar" 
                                          />
                                 </td>
                            </tr>
                        </tbody>
                    </table>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="lstOrigem" runat="server" SelectionMode="Multiple" Width="150px" Height="100px"></asp:ListBox>

                        

                        
                    </td>
                    <td>
                        <div>
                            <asp:Button ID="btnAdicionar" runat="server" Text="&gt;" />
                            <asp:Button ID="btnRemover" runat="server" Text="&lt;"/>
                        </div>
                    </td>
                    <td>
                        <asp:ListBox ID="lstDestino" runat="server" SelectionMode="Multiple" Width="150px" Height="100px"></asp:ListBox>
                    </td>
                    
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
