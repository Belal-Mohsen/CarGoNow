   M S B A M L   `   `   `  ����F  BCarGoNowApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CarGoNowAppCarGoNowApp  5   	       CarGoNowApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CarGoNowApp     5   	     � Title$  LogIn��5      $	��600��6#   $
��1200��60   $	��600��5	      $
��1200��6   .��5      � $	��950��6   $	��550��6   .+�5   
   ��  �� CornerRadius$ 50,50,50,25��6   $��29,33,153,25q�6,    J� RenderTransformOrigin$ 0.5,0.5&�6B   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.064Q�6&   T� 5      5      ��5      �� 5       j� Stretch$
 Fill=�6    �� ImageSource$ \Resources\bg-img-car.jpg��6,   ._�5      �� $��33,-4,-33,4q�6   5      � 5   
   $��555,70,0,70q�6   
������ $	��300��6=   $	��500��6L   .+�5      �� $ 	35,0,0,35��6   $��	0,0,-45,0q�6.   ��5      �� 5       $
 Fill=�6!   $ \Resources\bg-img.png��60   ._�5"      �� $��LOG IN��6   $��Center=�6)   $��69��6F   $��0,33,0,0q�6R   $	��Top=�6d   $	��182��6|   $
��Bold"�6�   $��36(�6�   $��Center=�5#      ���	#FFF4F0F0$��Comic Sans MS)�6O   5$      5%      �� 5&   
   $
��Left=�6   $��77��6+   $��	33,41,0,0q�67   $	��Top=�6J   $	��303��6b   $��\Resources\logo.png��6n   �� 5'   
   -   5         ��Name$ 	login_btn��5'      $��Log in��6$   $
��Left=�65   $��713,393,0,0q�6P   $	��Top=�6e   $	��134��6}   $��37��6�   ���	#FFE7F7EA���	#FF161111$
��Bold"�6�   $��18(�6�   $��Comic Sans MS)�6�   6�   �� 5(   
   -   5         ��Name$ user_name_input��5(      $
��Left=�6+   $��646,211,0,0q�6F    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $��38��6�   $	��268��6�   ���	#FF191818$��16(�6�   ���	#FFE7F7EA6�   G� 5)   
   -   5        	 G�Name$	 password_input��5)      $
��Left=�6.   $��646,285,0,0q�6I   $	��Top=�6_   $��38��6w   $	��268��6�   ���	#FF191818$��16(�6�   ���	#FFE7F7EA6�   	� 5*   
   -   5        
 	�Name$
 login_manager_btn��5*      $��Manager��61   $
��Left=�6C   $��687,333,0,0q�6^   $	��Top=�6s   ���	#FFF1EDED$
��Bold"�6�   $��Comic Sans MS)�6�   $��14(�6�   	� 5+   
   -   5        $
 login_em_btn��5+      $��Employee��6,   $
��Left=�6?   $��780,333,0,0q�6Z   $	��Top=�6o   ���	#FFF1EDED$
��Bold"�6�   $��Comic Sans MS)�6�   $��14(�6�   �� 5,   
   $
��Left=�6   $��646,180,0,0q�6,   $	��Top=�6A   $��UserName��6Y   ���	#FFFCFAFA$��Comic Sans MS)�6�   $��14(�6�   �� 5-   
   $
��Left=�6   $��646,255,0,0q�6,   $	��Top=�6A   $��Password��6Y   ���	#FFFCFAFA$��Comic Sans MS)�6�   $��14(�6�   50      51      