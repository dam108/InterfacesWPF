   M S B A M L   `   `   `  ����W  SPractica05_WPF_TreeView_JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Practica05_WPF_TreeView_JADFPractica05_WPF_TreeView_JADF  5   	   -    'Practica05_WPF_TreeView_JADF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Practica05_WPF_TreeView_JADF     5   	     � Title$4  .Practica04 Doval Fraga Jose Angel WPF_ListView��5   	   $	��550��6@   $
��1000��6M   $��Segoe UI Semibold)�5	   
   $��14(�6)    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        -   'Practica05_WPF_TreeView_JADF.MainWindow!   mostrarTrabajadoresCommand   Command# Z 5      5        5   
   -   5           añadirLocalidadCommand# Z 5      5        5   
   -   5           altaTrabajadorCommand# Z 5      5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF59BDB4��6   	 � Offset$	 0Q�61   � 5      $ 	#FF2E5350��6   $	 1Q�61   5      
 � ColumnDefinitions
 5   
   �� 5       $
��500* �6   �� 5!      $
��500* �6   .+�5$   
   R� -   5         R�Name$ trabajadores_TreeView��5$      $��25q�62   $��0��6>    � 	Resources 5%       �� DataType,   &Practica05_WPF_TreeView_JADF.Cuadrilla �� ItemsSource �� Orientation ��Name �� Triggers �� Value �� Binding �� RelativeSource �� AncestorType �� Path �� 
TargetName �� Property �� Value �� ItemTemplate,   &Practica05_WPF_TreeView_JADF.Localidad'   !Practica05_WPF_TreeView_JADF.Jefe+   %Practica05_WPF_TreeView_JADF.Oficial1+   %Practica05_WPF_TreeView_JADF.Oficial2��%�	  (��       5&   +   *, +)�� 6   "  6+    6O   �� *Localidades+.R�5'      �� $ 
Horizontal=�6!   .+�5(      �� $ iconoCuadrilla��6    $��/icons/carpetaCerrada.png��68   $��16��6[   $��16��6g   $��0,5,5,0q�6r   �� 5)      ��6$   �� *Nombre+5*       5+      �� 5,      $
 True��6�    6&   ��  �� $ TreeViewItemL�$ 
IsExpanded�.a�5-      �� $ iconoCuadrilla��6%    � ��$ icons/carpetaAbierta.png��5/   %   50       52      �� 53      "  63    6W   �� *jefes+(��       63   *, +).R�54      �� $ 
Horizontal=�6)   .+�55   "   �� $ iconoLocalidades��6(   $��/icons/carpetaCerrada.png��6B   $��16��6e   $��16��6q   $��0,5,5,0q�6|   �� 56   "   ��6,   �� *Nombre+57       58      �� 59   "   $
 True��6�    6.   ��  �� $ TreeViewItemL�$ 
IsExpanded�.a�5:   &   �� $ iconoLocalidades��6-    � ��$ icons/carpetaAbierta.png��5<   %   5=   #    5?      �� 5@   "   "  6;    6Z   �� *primerosOficiales+(��       6;   *, +).R�5A   &   �� $ 
Horizontal=�61   .+�5B   *   �� $ 	iconoJefe��60   $��/icons/carpetaCerrada.png��6C   $��16��6f   $��16��6r   $��0,5,5,0q�6}   �� 5C   *   ��64   �� *Descripcion+5D   '    5E   &   �� 5F   *   $
 True��6�    66   ��  �� $ TreeViewItemL�$ 
IsExpanded�.a�5G   .   �� $ 	iconoJefe��65    � ��$ icons/carpetaAbierta.png��5I   5   5J   +    5L   &   �� 5M   *   "  6C    6f   �� *segundosOficiales+(��       6C   *, +).R�5N   .   �� $ 
Horizontal=�69   .+�5O   2   �� $ iconoPrimerOficial��68   $��/icons/carpetaCerrada.png��6T   $��16��6w   $��16��6�   $��0,5,5,0q�6�   �� 5P   2   ��6<   �� *Descripcion+5Q   /    5R   .   �� 5S   2   $
 True��6�    6>   ��  �� $ TreeViewItemL�$ 
IsExpanded�.a�5T   6   �� $ iconoPrimerOficial��6=    � ��$ icons/carpetaAbierta.png��5V   5   5W   3    5Y   .   �� 5Z   2   "  6K   (��       *, +).R�5[   6   �� $ 
Horizontal=�6A   .+�5\   :   �� $ iconoSegundoOficial��6@   $��/icons/archivo.png��6]   $��16��6y   $��16��6�   $��0,5,5,0q�6�   �� 5]   :   ��6D   �� *Descripcion+5^   7    5_   6   �� 5`   :   $
 True��6�    6F   ��  �� $ TreeViewItemL�$ 
IsSelected�.a�5a   >   �� $ iconoSegundoOficial��6E    � ��$ icons/archivoAbierto.png��5c   E   5d   ;   5f   3   5h   +   5j   #   5l      5n      5o      5p      �� 5q   
   $��1��6   $��25q�6!   ._�5r      �� $ Vertical=�6   .+�5s      ]� $��30��6   .+�5t      �� $��
Localidad:��6   $��0,0,10,0q�61   �� 5u      -   5         ��Name$ localidad_TextBox��5u      $�� ��69   $	��130��6A   $��Segoe UI Semibold)�6N   $��14(�6m   $��Center=�6{   $��Center=�6�   $��1��6�   �� 5v      -   5         ��Name$ altaLocalidad_Btn��5v      $��Right=�68   $	��200��6O   $��Alta Localidad��6[   $��2��6t   #��Z 5w      �� 5x      5y      �� 5z      $	��150��6   $��Nuevo Empleado��6(   $��0,10,0,0q�6@   .��5{      � .+�5|      �� $��Nombre��6    $
��Left=�61   $��	30,20,0,0q�6L   $	��Top=�6_   �� 5}      $��Apellido��6    $
��Left=�63   $��	30,70,0,0q�6N   $	��Top=�6a   �� 5~      -   5        $ nombre_TextBox��5~   "   $
��Left=�6:   $��29��6U   $��	97,20,0,0q�6a    �� TextWrapping$
 Wrap=�6t   $�� ��5   "   $	��Top=�6*   $	��230��6B   $��Center=�6N   $��3��6p   �� 5�      -   5        $ Apellido_TextBox��5�   "   $
��Left=�6<   $��29��6W   $��	98,70,0,0q�6c   $
 Wrap=�6v   $�� ��5�   "   $	��Top=�6*   $	��229��6B   $��Center=�6N   $��4��6p   �� 5�      -	   5        $ altaEmpleado_Btn��5�   !   $
��Alta��6;   $
��Left=�6J   $��
332,20,0,0q�6e   $	��Top=�5�   !   $��92��69   $��29��6D   $��5��6P   #��Z 5�   !   5�      5�      ]� 5�      $��30��6   $��0,10,0,0q�6(   .+�5�      �� $��Localidades:��6   $��0,0,15,0q�64   �� 5�      -
   5         ��Name$ localidades_ComboBox��5�      $	��175��6>   $��Segoe UI Semibold)�6K   $��14(�6j    �� DisplayMemberPath$ Nombre��6x   $��Center=�5�      $��Center=�6A   $��6��6e   �� 5�      -   5        $ trabajadores_Btn��5�      $��Right=�67   $	��150��6N   $��Trabajadores��6Z   $��7��6q   #��Z 5�      �� 5�      5�      �� 5�      -   5          ��Name$  trabajadores_ListView��5�      $��0,10,0,0q�6;   $	��229��6N   $��8��6[   ! �� View! 5�      �� 5�      .P�5�      �� $��Nombre��6-   " �� Width$	" 150��6=   # �� DisplayMemberBinding# 6I   �� *Nombre+�� 5�      $��Apellido��6-   $	" 150��6?   # 6K   �� *
Apellido+�� 5�      $��Cargo��6-   $	" 150��6<   # 6H   �� *Cargo+5�      5�      5�      5�      5�      5�      