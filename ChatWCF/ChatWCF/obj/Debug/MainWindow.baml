   M S B A M L   `   `   `  ����B  >ChatWCF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatWCFChatWCF  5   	       ChatWCF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ChatWCF     5   	   -   5          � Title$  
MainWindow��5   	   $��514.333��6   $	��655��6-   .��5	      � .+�5
   
   o� $��25��6   $	��Top=�6   .@�5      m� $
��Menu��6   .@�5      m� -   5        $��Login��5      6*   m� 5      -   5        $��Registration��5      61   m� 5      -   5        $��Create Chat��5      60   m� 5      -   5        $
��Exit��5      6)   5      m� 5      $
��Help��6   5      �� 5   
   -   5        $��ChatTextBox��5      $
��Left=�6%   $	��205��6@   $��	10,61,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��463��6�   $
��Auto=�6�   �� 5   
   -   5        $��WriteMsgTextBox��5      $
��Left=�6)   $��10,304,0,41q�6D   $
 Wrap=�6Y   $	��463��6m   $
��Auto=�6y   �� 5   
   -   5        $��SendBtn��5      $
��Send��6    $
��Left=�6/   $��398,449,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5   
   $��Available chats��6   $
��Left=�6*   $��496,148,0,0q�6E   $	��Top=�6Z   �� 5   
   -	   5        $��ChatListBox��5      $
��Left=�6%   $��67��6@   $��496,179,0,0q�6L   $	��Top=�6a   $	��120��6y   �� 5   
   $
��User��6   $
��Left=�6   $��
496,30,0,0q�6:   $	��Top=�6N   �� 5   
   -
   5        $��UserTextBox��5      $
��Left=�6%   $��23��6@   $��
496,61,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   $��Current chat��6   $
��Left=�6'   $��
496,89,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $��CurrentChatTextBox��5      $
��Left=�6,   $��23��6G   $��496,120,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $��
SetChatBtn��5      $��Select Chat��6#   $
��Left=�69   $��496,257,0,0q�6T   $	��Top=�6i   $	��120��6�   6�   �� 5   
   $
��Chat��6   $
��Left=�6   $��	10,30,0,0q�6:   $	��Top=�6M   $��39��6e   �� 5   
   $��Write Message��6   $
��Left=�6(   $��
11,273,0,0q�6C   $	��Top=�6W   �� 5   
   $��	All Chats��6   $
��Left=�6$   $��496,295,0,0q�6?   $	��Top=�6T   �� 5    
   -   5        $��AllChatListBox��5       $
��Left=�6(   $	��100��6C   $��496,326,0,0q�6P   $	��Top=�6e   $	��120��6}   �� 5!   
   -   5        $��JoinChatBtn��5!      $��Join in Chat��6$   $
��Left=�6;   $��496,437,0,0q�6V   $	��Top=�6k   $	��120��6�   6�   5"      5#      