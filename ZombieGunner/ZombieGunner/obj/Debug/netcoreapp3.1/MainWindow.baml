   M S B A M L   `   `   `  ����G  CZombieGunner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ZombieGunnerZombieGunner  5   	       ZombieGunner.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ZombieGunner     5   	   -   5          � Title$  ZombieGunner��5   	   $	��450��6   $	��800��6+   .��5	      � ��5
   
   �� 5       �� ImageSource$ ./zombieGunnerBg.png��6   .+�5   
   �� $��Zombie��6   $
��Left=�6!   $��56��6<   $��	30,40,0,0q�6H   $	��Top=�6[   $	��162��6s   $
��32pt(�6   �� 5   
   $��Gunner��6   $
��Left=�6!   $��56��6<   $��100,100,0,0q�6H   $	��Top=�6]   $	��162��6u   $
��32pt(�6�   �� 5   
   -   5         ��Name$ 
playButton��5      $
��16pt(�6%   $
��Play��65   $
��Left=�6D   $��50��6_   $	��Top=�6k   $	��100��6�    ^� ShowOnDisabled$
 True��6�   $��
81,187,0,0q�6�    J� RenderTransformOrigin$ 0.517,0.542&�6�   �� 5   
   -   5        $
��Exit��5      $
��16pt(�6    $
��Left=�60   $��50��6K   $	��Top=�6W   $	��100��6o   $��
81,250,0,0q�6{   6�   �� 5   
   $��	Highscore��6   $
��Left=�6$   $��52��6?   $��
570,88,0,0q�6K   $	��Top=�6_   $	��150��6w   $
��23pt(�6�   �� 5   
   -   5         ��Name$ nameEingabe��5      $
��Left=�6'   $��31��6B   $��545,375,0,0q�6N   $
��15pt(�6c    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��200��6�   6�   �� 5   
   $��Gib deinen Namen ein��6   $
��Left=�6/   $��Center=�6J   $��24��6n   $��570,346,0,0q�6z   $	��Top=�6�   $	��150��6�   
�������$
��10pt(�6�   �� 5   
   -   5         ��Name$
 High��5      $
��Left=�6    $	��200��6;   $��570,140,0,0q�6H   $	��Top=�6]   $	��150��6u   5      5      