   M S B A M L   `   `   `  ����b  ^Practica02-B_WPF_Combo_PictureBox__JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Practica02_B_WPF_Combo_PictureBox__JADF'Practica02_B_WPF_Combo_PictureBox__JADF  5   	   8    2Practica02_B_WPF_Combo_PictureBox__JADF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:Practica02_B_WPF_Combo_PictureBox__JADF     5   	     � Title$7  1Practica02-B Doval Fraga, Jose Angel WPF Combobox��5   	   $	��420��6C   $	��800��6P   $��14(�6\      GradienteBacgroundRojo#���   5	   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.New��5      6b   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   �� $
��Left=�6   $	��Top=�60   $	��782��6H   $	��379��6W   .+�5      �� $��Información��6   $��20q�6,   $
��Left=�68   $	��Top=�6S   $	��742��6k   $	��137��6z   .��5      � $��20q�6   .+�5      �� $��	Provincia��6   $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   �� 5      $��	Localidad��6   $
��Left=�60   $��	10,44,0,0q�6K   $	��Top=�6^   �� 5      -   5         ��Name$ provincias_ComboBox��5      $
��Left=�6<   $��
100,14,0,0q�6W   $	��Top=�6k   $	��590��6�   $��0��6�    �� DisplayMemberPath$ Nombre��6�   ��6�   �� *
Provincias+6�   �� 5      -   5        $ localidades_ComboBox��5      $
��Left=�6=   $��
100,48,0,0q�6X   $	��Top=�6l   $	��590��6�   $��1��6�   $ Nombre��6�   5      5      �� 5      $��1��6   $��Gestión información��6$   $��20,20,20,24q�6A   $
��Left=�6V   $	��Top=�6q   $	��742��6�   $	��151��6�   .��5      � $��10q�6   .+�5      	� -   5         	�Name$ eliminar_Localidad_Rbtn��5   "   $%��Eliminar localidad seleccionada��6C   $
��Left=�6m   $��	10,10,0,0q�6�   $	��Top=�6�   $��2��6�   	� 5      -   5        $ modificar_Localidad_Rbtn��5   "   $&�� Modificar localidad seleccionada��6D   $
��Left=�6o   $��	10,33,0,0q�6�   $	��Top=�6�   $��3��6�   	� 5      -   5        $ nueva_Localidad_Rbtn��5   "   $��Nueva Localidad��6@   $
��Left=�6Z   $��	10,56,0,0q�6u   $	��Top=�6�   $��4��6�   �� 5      $��	Localidad��6   $
��Left=�60   $��	10,81,0,0q�6K   $	��Top=�6^   �� 5      -   5         ��Name$ nueva_Localidad_TextBox��5      $
��Left=�6?   $��29��6Z   $��	84,81,0,0q�6f    �� TextWrapping$
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��626��6�   $��6��6�   �� 5       -   5         ��Name$ ejecutar_Btn��5       $��EJECUTAR��63   $
��Left=�6F   $��15q�6a   $��
286,10,0,0q�6n   $	��Top=�6�   $��64��6�   $	��424��6�   $��7��6�   $��ApplicationCommands.New��6�   5!      5"      5#      5$      5%      