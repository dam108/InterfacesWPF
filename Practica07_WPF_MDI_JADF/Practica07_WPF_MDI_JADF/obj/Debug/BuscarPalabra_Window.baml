   M S B A M L   `   `   `  ����R  NPractica07_WPF_MDI_JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Practica07_WPF_MDI_JADFPractica07_WPF_MDI_JADF  5   	   2    ,Practica07_WPF_MDI_JADF.BuscarPalabra_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Practica07_WPF_MDI_JADF     5   	     � Title$  Buscar Palabra��5   	   $	��455��6    $	��705��6-    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        2   ,Practica07_WPF_MDI_JADF.BuscarPalabra_Window   BuscarCommand   Command# Z 5      5      .��5   
   � .+�5   
   �� -   5         ��Name$ mostrarTexto_RichTextBox��5      $
��Left=�68   $	��399��6S   $��	10,10,0,0q�6`   $	��Top=�6s   $	��366��6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��Abrir Documento��5      68   5      5      �� 5   
   -   5         ��Name$ mostrarLineas_ListBox��5      $
��Left=�61   $	��239��6L   $��417,170,0,0q�6Y   $	��Top=�6n   $	��265��6�    �� DisplayMemberPath$ NombreMostrar��5   5   ��6   ��  �� Path$ lineas� 5      �� 5      .@�5      m� -   5        $��Borrar Linea��5      65   m� 5      -   5        $!��Copiar Linea a otro archivo��5      6D   5      5#      �� 5%   
   -   5        	 ��Name$	 palabraBuscar_TextBox��5%      $
��Left=�61   $��23��6L   $��
562,74,0,0q�6X   
 �� TextWrapping$

 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   �� 5&   
   $��Palabra a Buscar��6   $
��Left=�6+   $��
443,70,0,0q�6F   $	��Top=�6Z   $	��114��6r   �� 5'   
   -   5         ��Name$ 
buscar_Btn��5'      $��Buscar��6%   $
��Left=�66   $��569,135,0,0q�6Q   $	��Top=�6f   $	��113��6~   $��30��6�   #��Z 5(      5)      5*      