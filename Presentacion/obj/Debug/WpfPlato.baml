   M S B A M L   `   `   `  ����G  CPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentacionPresentacion  5   	       Presentacion.WpfPlato   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentacion     5   	     � Title$  Gestion de Platos��5   	   $	��360��6#   $	��299��60   .��5	      � $��0,0,2,-8q�6   .+�5
   
   �� -   5         ��Name$ label��5
      $��Nombre del Plato :��6   $
��Left=�6<   $��	20,40,0,0q�6W   $	��Top=�6j    J� RenderTransformOrigin$ 0.803,-0.058&�6�   �� 5   
   -   5        $ label1��5      $��Precio del Plato :��6    $
��Left=�6=   $��	20,82,0,0q�6X   $	��Top=�6k   �� 5   
   -   5         ��Name$ 
txtNombreP��5      $
��Left=�6&   $��24��6A   $��
154,44,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   6�   �� 5   
   -   5        $ 
txtPrecioP��5      $
��Left=�6&   $��23��6A   $��
154,86,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
38,133,0,0q�6R   $	��Top=�6f   $	��109��6~   6�   �� 5   
   -   5        $ btnModificar��5      $��	Modificar��6'   $
��Left=�6;   $��154,133,0,0q�6V   $	��Top=�6k   $��98��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPlatos��5      $
��Left=�6%   $��
20,167,0,0q�6@   $	��Top=�6T   $	��127��6l   $	��254��6y      
IsReadOnly . 6�   5      5      