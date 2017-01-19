<table  border="0">
  <tr>
     <td>
       <img src='Catalog/Images/<%# Eval("ProductImage") %>'  border="0" 
                                                   alt='<%# Eval("ModelName") %>' />
     </td>
     <td><%# Eval("Description") %><br /><br /><br />  
         <uc1:AlsoPurchased ID="AlsoPurchased1" runat="server" />                 
     </td>
   </tr>
</table>