   M S B A M L   `   `   `  ����R  NPractica06_WPF_SDI_JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Practica06_WPF_SDI_JADFPractica06_WPF_SDI_JADF  5   	   (    "Practica06_WPF_SDI_JADF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Practica06_WPF_SDI_JADF     5   	     � Title$,  &Doval Fraga Jose Angel Practica 06 WPF��5   	   $	��350��68   $
��1000��6E   $��14(�6R      DegradadoVentanaPrincipal#���   5	   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        (   "Practica06_WPF_SDI_JADF.MainWindow   lanzarHijaACommand   Command# Z 5      5        5   
   -   5           lanzarHijaBCommand# Z 5      5        5   
   -   5           lanzarHijaCCommand# Z 5      5        5   
   -   5           MostrarCommand# Z 5      5        5   
   -   5           OcultarCommand# Z 5      5        5   
   -   5           CerrarCommand# Z 5      5      .��5#      � 	 � RowDefinitions	 5$   
   �� 5%      $
��300* �6   �� 5&      $	��50* �6   .+�5(   
   �� 
 �� Orientation$
 
Horizontal=�6   .+�5)      �� $	��150��6   $
��Left=�6!   ._�5*      �� $��10,20q�6   .+�5+      �� -   5         ��Name$ 	hijaA_Btn��5+      $��Hija A��60     RoundCorner#���  6A   #��Z 6g   �� 5,      -   5        $ 	hijaB_Btn��5,      $��Hija B��60   #���  6A   #��Z 6g   �� 5-      -	   5        $ 	hijaC_Btn��5-      $��Hija C��60   #���  6A   #��Z 6g   5.      5/      �� 50      $��Mostrar��6   
�������$��10,20q�6;   $	��125��6J   .��51      �� $
 Vertical=�6   $��10q�64   .+�52      	� -
   5         	�Name$ mostrar_TipoA_rbt��52   "   $��Tipo A��6=   6P   	� 53      -   5        $ mostrar_TipoB_rbt��53   "   $��Tipo B��6=   6P   	� 54      -   5        $ mostrar_TipoC_rbt��54   "   $��Tipo C��6=   6Q   	� 55      -   5        $ mostrar_Todas_rbt��55   "   $��Todas��6=   6O   �� 56      -   5        $ mostar_Rbt_Btn��56      $��Mostrar��65   $��0,30,0,0q�6G   #���  6Y   #��Z 6   $��1��6�   57      58      �� 59      $��Ocultar��6   
�������$��10,20q�6;   $	��125��6J   .��5:      �� $
 Vertical=�6   $��10q�64   .+�5;      	� -   5        $ ocultar_TipoA_rbt��5;   "   $��Tipo A��6=   6P   	� 5<      -   5        $ ocultar_TipoB_rbt��5<   "   $��Tipo B��6=   6P   	� 5=      -   5        $ ocultar_TipoC_rbt��5=   "   $��Tipo C��6=   6Q   	� 5>      -   5        $ ocultar_Todas_rbt��5>   "   $��Todas��6=   6O   �� 5?      -   5        $ ocultar_Rbt_Btn��5?      $��Ocultar��66   $��0,30,0,0q�6H   #���  6Z   #��Z 6�   $��1��6�   5@      5A      �� 5B      $��Ventanas hijas��6   
�������$��10,20q�6B   .��5C      �� $
 Vertical=�6   $��10q�64   .+�5D      �� -   5         ��Name$ ventanas_ListBox��5D      $	��140��68   $	��500��6E    �� DisplayMemberPath$ TituloCompleto��6w   ��6Q   ��  �� Path$ ventanas�6w   �� 5E      $
 
Horizontal=�6!   $��0,10,0,0q�6:   $��30��6M   $��Center=�6Y   $��Center=�6v   .+�5F      �� -   5        $ mostar_list_Btn��5F   !   $��Mostrar��6:   $��30��6L   $	��100��6X   $��	10,0,10,0q�6d   $��	10,0,10,0q�6x   #���  6�   #��Z 6�   $��2��6�   �� 5G      -   5        $ ocultar_list_Btn��5G   !   $��Ocultar��6;   $��30��6M   $	��100��6Y   $��	10,0,10,0q�6e   $��	10,0,10,0q�6y   #���  6�   #��Z 6�   $��2��6�   �� 5H      -   5        $ cerrar_list_Btn��5H   !   $��Cerrar��6:   $��30��6K   $	��100��6W   $��	10,0,10,0q�6c   $��	10,0,10,0q�6w   #���  6�   #��Z 6�   5I      5J      5K      5L      �� 5M   
   -   5         ��Name$ numeroVentanas_Lbl��5M      $�� ��6,   $��Center=�67   $��Center=�6T   $��1��6o   
�������6|   5O      5P      