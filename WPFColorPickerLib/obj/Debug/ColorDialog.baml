   M S B A M L   `   `   `  ����L  HWPFColorPickerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFColorPickerLibWPFColorPickerLib  5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls 5   	   #    WPFColorPickerLib.ColorDialog   5   	   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   /localclr-namespace:WPFColorPickerLib    5   	   WcontrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework    5   	     � Title$  Выбор цвета��5   	   $	��290��5   	   $	��190��5   	   
����� � � WindowStartupLocation$ CenterOwner=�5
   	    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6C    � ShowActivated .   � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Verdana)�6+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   5      �� 5   
   " ��6   .�5      ��  � ��
 ��  �6,   �� 5       � ��$ 3q�60   �� 5       � ��
 �����6+   �� 5       � ��
 ��  �6+   5      5      .��5       � 	 � RowDefinitions	 5!   
   �� 5"      $	��210 �6   �� 5#      $��40 �6   
 � ColumnDefinitions
 5%   
   �� 5&      �� 5'      .+�5+   
   #   WPFColorPickerLib.ColorPicker  -   5          Name$ colorPicker��5+      #   WPFColorPickerLib.ColorPicker   Loaded$ colorPicker_Loaded��5-   %   $��2��5,      $��2��5-      $��
10,10,10,0q�6A   �� 5/   
   -   5         ��Name$ btnOK��5/      $��Принять��50       �� 	IsDefault . $��1��53      $��10,5,5,5q�54      �� 57   
   -   5        $ 	btnCancel��57      $��Отмена��58       �� IsCancel . $��1��5;      $��1��5<      $��5,5,10,5q�5=      5U      5V      