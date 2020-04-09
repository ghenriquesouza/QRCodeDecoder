Estudo de viabilidade para o uso de leitura do qrcode pela webcam

Criei um projeto web nos moldes ao que ja trabalhamos (pelo template do VS mesmo) Na pagina Index da Home eu envio uma imagem por ajax ao controller, em base64, e chamamos as bibliotecas para decodificar a imagem.

Utilizei duas bibliotecas publicas para leitura de qrcode:

A QRCodeDecoderLibrary, baixei o projeto, compilei e coloquei como arquivo na pasta dll interna E o plugin ZXing.Net, versao 0.16.5, baixado pelo Nuget.

A taxa de leitura correta pelo ZXing foi muito superior a primeira biblioteca.
