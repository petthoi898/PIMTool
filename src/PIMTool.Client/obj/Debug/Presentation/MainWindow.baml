   M S B A M L   `   `   `  ����I  EPIMTool.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PIMTool.Client.PresentationPIMTool.Client.Presentation  5   	   ]3clr-namespace:PIMTool.Client.Presentation.ViewModel%PIMTool.Client.Presentation.ViewModel  5   	   ,    &PIMTool.Client.Presentation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:PIMTool.Client.Presentation     5   	   J
viewmodels3clr-namespace:PIMTool.Client.Presentation.ViewModel     5   	     � Title$  PIMTool��5	   	   $	��900��6   $
��1350��6&    � 
ResizeMode$ NoResize=�63   .��5
      � ���	#FFF3F3F3 � 	Resources 5   
    �� DataType?   9PIMTool.Client.Presentation.ViewModel.NewProjectViewModel,   &PIMTool.Client.Presentation.NewProjectA   ;PIMTool.Client.Presentation.ViewModel.ProjectsListViewModel.   (PIMTool.Client.Presentation.ProjectsListD   >PIMTool.Client.Presentation.ViewModel.UnexpectedErrorViewModel1   +PIMTool.Client.Presentation.UnexpectedError��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $��0* �6   .+�5   
   �� $��1��6   ��6&   �� *SelectedViewModel+� 5   
   $��0��6   $��Center=�6   $��50��67   .+�5      ]� .+�5      ]� $
��Left=�6   .+�5       �� $ ��../Resources/logo_elca.png��6   $
��Left=�6@   $��10,0,0,0q�6[   6o   �� 5!      $$��Project Information Management��6    $��Center=�6F   $��30,0,0,0q�5"       $��18(�62   $��SemiBold"�6@   5#      5$      ]� 5%      $��Right=�6   $��Center=�68   $��	0,0,200,0q�6S   .+�5&      ]� .+�5'      �� $	��EN ��6$   �� 5(      $��| FR          Help��6$   
����  �6>   �� 5)      $��                 Log out��6$   
�������6D   5*      5+      5,      5-      �� 5.   
   $��1��6   	 �� X1$ 0��6   	 �� Y1$ 20��6#   	 �� X2$
 1500��6+   	 �� Y2$ 20��65   ���	#FFCDCDCD6R   �� 5/   
   $��1��51      $	 160��6   $ 20��6#   $	 160��6+   $
 2000��64   ���	#FFDCD9D9y�50      �� *IsUnexpectedError+    BooleanToVisibilityConverter	 �� 	Converter#	 [  51   S   � 52   
   $��1��6   $��
0,78.4,0,0q�6   $	��Top=�53      $
��Left=�6'   $	��200��54      $	��200��6   y�55      �� *IsUnexpectedError+#	 [  .+�56      � .+�57      �� $
��Auto��58      $
��Left=�5:      $��
10,0,0,170q�60   ��59      �� *NavigateProjectsListCommand+��5;      �� 5<      
 �� 
TargetType"
 ��6*   .R�5=      �� $��Center=�5>      $��Projects Lists��6:   $��18(�6P   $��SemiBold"�6^   5?      5A      �� 5B      $��10,50,5,120q�6   $��18(�6.   $��SemiBold"�6<   $
��Left=�5D      $��50��60   ��5C      �� *NavigateNewProjectCommand+��5E      �� 5F      "
 ��6*   .R�5G      �� ���#2F85FA$��Center=�5I   %   $	��New��6B   $��18(�6M   $��SemiBold"�6[   $��-2,0,-7.8,0q�6q   $��57��6�   5J      5L      �� 5M      $��93��6   $��77��6)   $��11,80,112,27q�64   $��Center=�6J   $��Center=�6g   .+�5N      �� $	��0,3q�6   $
��Left=�5P      $��50��60   ��5O      �� *NavigateNewProjectCommand+��5Q      �� 5R      "
 ��6.   .R�5S   "   �� ���	#FFB4B1B1$��Center=�5U   %   $��Project��6B   $��16(�6Q   $��SemiBold"�6_   $��-2,0,-7.8,0q�6u   $��57��6�   5V      5X      �� 5Y      ���	#FFB4B1B1$��	0,3,2.8,3q�67   $��Customer��6J   $��SemiBold"�6Z   $��16(�6p   �� 5Z      ���	#FFB4B1B1$��	0,3,2.8,3q�67   $��Supplier��6J   $��21��6Z   $��SemiBold"�6f   $��16(�6|   5[      5\      5]      5^      5`      