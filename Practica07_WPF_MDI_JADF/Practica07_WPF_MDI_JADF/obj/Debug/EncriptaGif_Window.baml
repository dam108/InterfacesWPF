   M S B A M L   `   `   `  ����R  NPractica07_WPF_MDI_JADF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Practica07_WPF_MDI_JADFPractica07_WPF_MDI_JADF  5   	   0    *Practica07_WPF_MDI_JADF.EncriptaGif_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Practica07_WPF_MDI_JADF     5   	     � Title$  Encriptar Gif��5   	   $	��455��6   $	��805��6,    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        0   *Practica07_WPF_MDI_JADF.EncriptaGif_Window   EncriptarArchivoCommand   Command# Z 5      5        5   
   -   5           EncriptarCarpetaCommand# Z 5      5        5   
   -   5           DesencriptarCommand# Z 5      5        5   
   -   5           MostarCommand# Z 5      5      .��5      � .+�5   
   �� -   5         ��Name$ gif_Picturebox��5      $
��Left=�6(   $	��399��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��377��6{   �� 5   
   -   5         ��Name$ gif_ListBox��5      $
��Left=�6'   $	��249��6B   $��
392,10,0,0q�6O   $	��Top=�6c   $	��215��6{   	 �� DisplayMemberPath$	 NombreMostrar��5   8   ��6   �� 
 �� Path$
 imagenes�6Z   �� 5   
   -   5         ��Name$ EncriptarGif_Btn��5      $��Encriptar Archivo GIF��6+   $
��Left=�6K   $��
612,10,0,0q�6f   $	��Top=�6z   $	��170��6�   $��40��6�   #��Z 5      �� 5   
   -   5        $ encriptarCarpeta_Btn��5      $��Encriptar Carpeta con GIF��6/   $
��Left=�6S   $��
612,55,0,0q�6n   $	��Top=�6�   $	��168��6�   $��40��6�   #��Z 5       �� 5!   
   -	   5        $ desenciptar_Btn��5!      $��Desencriptar��6*   $
��Left=�6A   $��612,100,0,0q�6\   $	��Top=�6q   $	��168��6�   $��40��6�   #��Z 5"      �� 5#   
   -
   5        $ mostrar_Btn��5#      $��Mostrar��6&   $
��Left=�68   $��612,145,0,0q�6S   $	��Top=�6h   $	��170��6�   $	��114��6�   #��Z 5$      � 5%   
   -   5         �Name$ barraDeProgreso��5%      $
��Left=�6/   $��51��6J   $��392,358,0,0q�6V   $	��Top=�6k   $	��388��6�   �� 5&   
   $"��Progreso de la encriptación��6   $
��Left=�66   $��392,327,0,0q�6Q   $	��Top=�6f   �� 5'   
   -   5         ��Name$ finalEncriptar_Lbl��5'      $��Encriptacion Finalizada��6,   $
��Left=�6N   $��648,327,0,0q�6i   $	��Top=�6~   $y�Hidden=�6�   5)      5*      