   M S B A M L   `   `   `  ����I  EPIMTool.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PIMTool.Client.Presentation.ViewModel%PIMTool.Client.Presentation.ViewModel  5      I)clr-namespace:PIMTool.Client.PresentationPIMTool.Client.Presentation  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          PIMTool.Client.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      J
viewmodels3clr-namespace:PIMTool.Client.Presentation.ViewModel     5      Bpresentation)clr-namespace:PIMTool.Client.Presentation     5      9system&clr-namespace:System;assembly=mscorlib     5        �� 	Resources  5          BooleanToVisibilityConverter �� 
TargetType �� Property �� Value 
 Header  StatusResource �� Type  errorTemplate  MyWaterMarkStyle �� 	Resources �� 
TargetType ��Name ��Name
	 � Tag
 �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value  RoundButton  RoundTextBox  ComboBoxTextBoxStyle �� CornerRadius  DockPanelLabelStyle��%h  &	        '��      '�� ]     &	 �     &	 �     &	 |    &	 s    &	 v    &	     &	 �    &	 �    �� 5   
   6'   �� 5	   
   " ��6   .�5
      ��  � ��$
 10 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 24(�6)   5      �� 5   
   " ��6)   .s�5      ��NEW��6!   ��5      INP��6!   ��5      PLA��6!   ��5      FIN��6!   5      �� 5   
   .R�5      �� 
��� E��$��2q�6-   ._�5      � .+�5      �� .v�5      �� 
��� E��$��Center=�6]   $��Right=�6x   $��0,0,4,0q�6�   ��6$   �� *[0].ErrorContent+6�   5      5       5!      5"      �� 5#   
   " ��6)    5$      ���� 5%      '��       " ��6   .�5&      ��  �@��CornerRadius$ 5��65   5'      5(      .�5)      ��  � �� 5*      �� 5+      " ��6&   .R�5,      � .+�5-      �� 
����������	#FF7D8683$��1q�6P   �� 5.      $ PART_ContentHost��6+   $��5,0,0,0q�6E   $��Center=�6V   �� 5/      $ WaterMarkLabel��65   $��5,0,0,0q�6$   #��z	 6M   $��Center=�6m   $y�	Collapsed=�50   $   
�������$��Arial)�6M   51      
 52      ]� 53       54   "   �� 55   &    � ��$  ��6@   ./�57   "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   58      P� 59       � {� .  . �5:   "   ��  � ��
 �iii�6?   5;      5=      5?      5@      �� 5A   
   " ��6    5B      ���� 5C      '��       " ��6   .�5D      ��  �@��CornerRadius$ 3��65   5E      5F      5G      �� 5H   
   " ��6    5I      ���� 5J      '��       " ��6   .�5K      ��  �@��CornerRadius$ 5��65   5L      5M      5N      �� 5O   
   " ��6-   .�5P      ��  � �� 5Q      �� 5R      " ��6&   .R�5S      � .+�5T      �� $ 5,0,0,5��6%   $��1q�5U   %   #��z��5V   %   
���   �._�5X   "   �� $ PART_ContentHost��6/   5Y      5Z      5[      5]      5^      �� 5_   
   .�5`      ��  � ��$	 110��6.   5a      5c      5d      