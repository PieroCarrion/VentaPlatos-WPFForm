   M S B A M L   `   `   `  ����G  CPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentacionPresentacion  5   	       Presentacion.WpfCliente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentacion     5   	     � Title$  Gestion de Clientes��5   	   $	��350��6%   $	��291��62   .��5	      � $��0,0,2,-6q�6   .+�5
   
   �� -   5         ��Name$ label��5
      $��Nombre :��6   $
��Left=�62   $��	34,27,0,0q�6M   $	��Top=�6`   �� 5   
   -   5         ��Name$ 
txtNombreC��5      $
��Left=�6&   $��23��6A   $��
136,26,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   6�   �� 5   
   -   5        $ label1��5      $��
Apellido :��6    $
��Left=�65   $��	34,50,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ txtApellidoC��5      $
��Left=�6(   $��23��6C   $��
136,57,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   6�   �� 5   
   -   5        $ label2��5      $��Dirección :��6    $
��Left=�66   $��	34,85,0,0q�6Q   $	��Top=�6d    J� RenderTransformOrigin$ -0.105,0.577&�6|   �� 5   
   -   5        $ txtDireccionC��5      $
��Left=�6)   $��23��6D   $��
136,90,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   6�   �� 5   
   -   5        $ label3��5      $��Teléfono :��6    $
��Left=�65   $��
34,119,0,0q�6P   $	��Top=�6d   $ 0.263,-0.308&�6|   �� 5   
   -   5        $ txtTelefonoC��5      $
��Left=�6(   $��23��6C   $��136,125,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   6�   �� 5   
   -	   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
49,161,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -
   5        $ btnModificar��5      $��	Modificar��6'   $
��Left=�6;   $��147,161,0,0q�6V   $	��Top=�6k   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgClientes��5      $
��Left=�6'   $��
24,199,0,0q�6B   $	��Top=�6V   $	��106��6n   $	��235��6{      
IsReadOnly . 6�   �� 5   
   -   5        $ 
label_Copy��5      $	��DNI��6$   $
��Left=�62   $��35,0,0,0q�6M   $	��Top=�6_   �� 5   
   -   5        $ txt_DNI��5      $
��Left=�6#   $��23��6>   $��
136,-1,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   6�   5      5      