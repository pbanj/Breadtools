F i l e E x t e n s i o n   =   " H K C U \ S o f t w a r e \ M i c r o s o f t \ W i n d o w s \ C u r r e n t V e r s i o n \ E x p l o r e r \ A d v a n c e d \ H i d e F i l e E x t "  
 S e t   C o m m a n d 1   =   W S c r i p t . C r e a t e O b j e c t ( " W S c r i p t . S h e l l " )  
 C h e c k   =   C o m m a n d 1 . R e g R e a d ( F i l e E x t e n s i o n )  
 I f   C h e c k   =   1   T h e n  
 C o m m a n d 1 . R e g W r i t e   F i l e E x t e n s i o n ,   0 ,   " R E G _ D W O R D "  
 E l s e  
 C o m m a n d 1 . R e g W r i t e   F i l e E x t e n s i o n ,   1 ,   " R E G _ D W O R D "  
 E n d   I f  
 C o m m a n d 1 . S e n d K e y s   " { F 5 } " 