   M S B A M L   `   `   `  ����R  NPractica07_WPF_MDI_JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Practica07_WPF_MDI_JADFPractica07_WPF_MDI_JADF  5   	   4    .Practica07_WPF_MDI_JADF.OrganizarVideos_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Practica07_WPF_MDI_JADF     5   	     � Title$  Organizar Videos��5   	   $	��455��6"   $	��705��6/    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5        4   .Practica07_WPF_MDI_JADF.OrganizarVideos_Window    SeleccionarCarpetaCommand   Command# Z 5
      5        5   
   -   5           OrganizarCommand# Z 5      5      .��5   
   � .+�5      R� -   5         R�Name$ carpetas_TreeView��5      $
��Left=�62   $	��368��6M   $��	10,41,0,0q�6Z   $	��Top=�6m   $	��243��6�   6�   �� 5      -   5         ��Name$ videos_ListBox��5      $
��Left=�6.   $	��368��6I   $��
258,41,0,0q�6V   $	��Top=�6j   $	��170��6�    �� DisplayMemberPath$
 Name��5   :   ��6   ��  �� Path$ videos�6S   �� 5      -   5        	 ��Name$	 seleccionarCarpeta_Btn��5      $��Seleccionar Carpeta��65   $
��Left=�6S   $��
433,41,0,0q�6n   $	��Top=�6�   $	��249��6�   $��50��6�   #��Z 5      �� 5      -   5        $	 Organizar_Btn��5      $��	Organizar��6,   $
��Left=�6@   $��433,354,0,0q�6[   $	��Top=�6p   $	��249��6�   $��55��6�   #��Z 5      �� 5      -   5        
 ��Name$
 carpetaSeleccionada_Lbl��5      $��Carpeta Seleccionada��65   $
��Left=�6T   $��433,119,0,0q�6o   $	��Top=�6�   �� 5      $��Carpetas��6   $
��Left=�6'   $��	10,10,0,0q�6B   $	��Top=�6U   �� 5      $!��Videos Carpeta Seleccionada��6   $
��Left=�6:   $��
258,10,0,0q�6U   $	��Top=�6i   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ organizar_DatePicker��5      $
��Left=�67   $��433,193,0,0q�6R   $	��Top=�6g   $	��249��6   �� 5      -	   5        $
 mostrarRutaCarpeta_Lbl��5      $�� ��64   $
��Left=�6?   $��433,150,0,0q�6Z   $	��Top=�6o   5       5!      