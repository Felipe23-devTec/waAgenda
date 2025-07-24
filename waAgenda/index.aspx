<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="waAgenda.index" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        Runat="server"/>
    <table border="1" style="margin-bottom: 15px;">
    <thead>
        <tr>
            <th>País</th>
            <th>Estado</th>
            <th>Capital</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Brasil</td>
            <td>Rio de Janeiro</td>
            <td>Rio de Janeiro</td>
        </tr>
        <tr>
            <td>Brasil</td>
            <td>São Paulo</td>
            <td>São Paulo</td>
        </tr>
        <tr>
            <td>Brasil</td>
            <td>Minas Gerais</td>
            <td>Belo Horizonte</td>
        </tr>
         <tr>
            <td>Brasil</td>
            <td>Acre</td>
            <td>Rio Branco</td>
        </tr>
    </tbody>
</table>
        <div>
            <div style="margin-bottom: 15px;">
              <label for="SearchTitle">Pesquise por um valor:</label>
              <asp:TextBox ID="search" runat="server" Width="136px" Height="15px"></asp:TextBox>
              <asp:Button ID="btnPesquisar" runat="server"  Text="Buscar" OnClick="btnPesquisar_Click"/>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"  OnRowDataBound="GridView1_RowDataBound" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Pais" HeaderText="País" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:Button  runat="server" Text="Ação" CommandName="CustomCommand" CommandArgument="<%# Container.DataItemIndex %>"/>
                            <asp:Button  runat="server" Text="Ação 2" CommandName="" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
   
    <div style="background: #ccc; border: 1px solid #353334f3; border-radius: 20px; width: 500px;
        height: 150px; padding: 20px; box-shadow: 3px 3px 3px #aaa4a4; margin:auto">
        <div class="card-header" style="margin: 6px 2px 10px 2px; background: #0976DB; padding: 1px; color: white; text-align:center; border-radius: 3px;">
               <p style="box-sizing: border-box; padding: 0px; margin: 5px;">Titulo de Destaque</p>
        </div>
        <table>
            <tr>
                <td style="width: 200px;"><asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label></td>
                <td style="width: 200px;"><asp:Label ID="Label2" runat="server" Text="Nome Social"></asp:Label></td>
                <td style="width: 200px;"><asp:Label ID="Label5" runat="server" Text="CPF"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 200px;"><asp:Label ID="Label3" runat="server" Text="Felipe Monteiro da Silva"></asp:Label></td>
                <td style="width: 200px;"><asp:Label ID="Label4" runat="server" Text="Não informado"></asp:Label></td>
                <td style="width: 200px;"><asp:Label ID="Label6" runat="server" Text="123.876.976-43"></asp:Label></td>
            </tr>
          </table>
    </div>
    <div>
        <%--<asp:GridView ID="gvBeneficiarios" runat="server" AutoGenerateColumns="False" Width="680px" EmptyDataText="Não há Beneficiário Cadastrado"
    OnRowDataBound="gvBeneficiarios_RowDataBound">
    <Columns>
        <asp:BoundField DataField="TpPessoaBenfcrio" HeaderText="Tipo de Pessoa Beneficiário" />
        <asp:BoundField DataField="CNPJ_CPFBenfcrio" HeaderText="CNPJ/CPF Beneficiário" />

        <asp:TemplateField HeaderText="Documento">
            <HeaderTemplate>
                <asp:Label ID="lblHeaderDoc" runat="server" Text="Documento" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblDocumento" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="TpBenfcrioCOR" HeaderText="Tipo de beneficiário COR" />
    </Columns>
</asp:GridView>--%>

        <asp:GridView ID="gvBeneficiario" runat="server" AutoGenerateColumns="False" Width="680px" EmptyDataText="Não há Beneficiário Cadastrado">
            <Columns>
                <asp:BoundField DataField="TpPessoaBenfcrio" HeaderText="Tipo de Pessoa Beneficiário" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                           <ItemStyle HorizontalAlign="Center" Width="140px"/>
                </asp:BoundField>
                <asp:BoundField DataField="CNPJ_CPFBenfcrio" HeaderText="CNPJ/CPF Beneficiário" />
                <asp:BoundField HeaderText="Documento Beneficiário" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:BoundField>
        
                <asp:BoundField DataField="TpBenfcrioCOR" HeaderText="Tipo de beneficiário COR" />
            </Columns>
        </asp:GridView>

    </div>
    <div>
        <table>
            <tbody>
                <tr>
                    <td>
                        
                        <asp:TextBox ID="txtNome" Caption="Nome" runat="server" />
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtEmail" Caption="Email" runat="server" />
                    </td>
                    <td id="tdDinamico" runat="server">
                        
                        
                    </td>
                </tr>
                <tr>
                    <td id="tdDinamico2" runat="server">
                        
                        
                    </td>
                    <td>
                        
                        <asp:TextBox ID="Text3" Caption="Email" runat="server" />
                    </td>
                    <td>
                        
                        <asp:TextBox ID="Text4" Caption="Texto 1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
           
    
</asp:Content>
