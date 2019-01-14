# O-Viajante
Repositório para o jogo, galeris ^^

Scripts feitos até agora:

# AbrirMenuPausa
  Atrelado ao EmptyGameObject "Gerenciadorjogo"
  Ativa o Menu de Pausa, congela o tempo do jogo e contém as funções de atividade dos botões (apenas sair do fogo por enquanto)
  
# Armadilha
  Atrelado aos Sprites "Armadilha"
  Controla o funcionamento da armadilha, chamando as funções de dano e efeitos para quando o Jogador encostar nela
  (OBS: Ver Script "Vida" para mais detalhes)
  
# Ativar Alavanca
  Atrelado aos Sprites "Alavanca"
  Controla a ativação da alavanca, seus efeitos (Desativar/Ativar áreas de radiação, por enquanto) e animações
  
# Audio
  Atrelado ao EmptyGameObject "GerenciadorÁudio"
  Script com um vetor de objetos da classe "Som" (que deverá conter todos os soms do jogo), deve ser usado para tocar qualquer um
  dos efeitos sonoros
  (OBS: Ver Script "Som" para mais detalhes)
  
# CameraSeguirJogador
  Atrelado à Camera "MainCamera"
  Controla o movimento da câmera de forma que siga o jogador conforme ele se move pelo cenário
  
# ContadorCristais
  Atrelado ao Texto "TextoContadorCristais"
  Atualiza o contador de cristais
  (OBS: Ver Script "PegarCristais" para mais detalhes)
  
# ItensJogador
  Atrelado ao Sprite "Jogador"
  Permite que o Jogador pegue itens e os largue no chão
  (OBS: Ver o Script "PegarPlutonio" para mais detalhes)
  
  # MovimentaçãoJogador
  Atrelado ao Sprite "Jogador"
  Controla o movimento do jogador e suas restrições
  
  # PanoDeFundoSegir
  Atrelado ao Sprite "PanoDeFundo"
  Faz com que o Sprite de background siga a camêra
  (OBS: SIM O NOME DELE ESTÁ "SEGIR" E NÃO "SEGUIR" ALGUÉM POR FAVOR ARRUMA ISSO OBG)
  
  # PegarCristal
  Atrelado aos Sprites "Cristal"
  Controla quando o Jogador pega um cristal e a animação envolvida
  
# PegarPlutonio
  Atrelado ao Sprite "Plutônio"
  Permite que o jogador pegue esse item
  (OBS: é possível generalizar esse Script para que sirva para qualquer "Item de Mão")
  
  # Radiação
  Atrelado aos Sprites "ÁreaRadiação"
  Controla o dano da área de radiação quando o Jogador a adentra
  
  # Som
  Atrelado ao EmptyGameObject "GerenciadorAudio"
  Script que contém a classe "Som" e seus atributos, que servem para definir Volume, Altura e Objeto Fonte dos Efeitos Sonoros
  
  # Vida
  Atrelado ao EmptyGameObject "GerenciadorJogo"
  Controla a quantidade e tipo de dano que o jogador toma, sendo também responsável por fazer o Jogador morrer
