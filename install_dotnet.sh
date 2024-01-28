#!/bin/bash

# Baixa o script de instalação do .NET
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

# Concede permissões de execução ao script
chmod +x dotnet-install.sh

# Executa o script de instalação do .NET, especificando a versão "Current"
./dotnet-install.sh -c Current

# Adiciona o diretório .dotnet ao PATH no arquivo .bashrc
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc

# Atualiza o ambiente atual com as modificações no .bashrc
source ~/.bashrc

# Mensagem indicando a conclusão da instalação
echo ".NET Core instalado com sucesso!"
