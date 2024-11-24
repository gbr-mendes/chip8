Tamanho: 4KB - 4096 bytes
Primeiros 512 bytes são reservados
Posso usar os primeiros 512 bytes para a fonte

Programas iniciam a partir do 0X200
Deve possibilitar escrita. Os jogos alteram eles mesmos


AS FONTES COMEÇA NO INDICE 80 E VÃO ATÉ O 159

---------------------------------------------------------
Display
64x32
---------------------------------------------------------
Stack
A stack será uma pilha que suporta até 16 endereços
Cada endereço pode possuir até 16 bits, mas data a limitação do chip8, apenas 12 são endereçados
---------------------------------------------------------
Revisar a velocidade de execução das intruções