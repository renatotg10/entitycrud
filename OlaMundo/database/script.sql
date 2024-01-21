CREATE DATABASE IF NOT EXISTS livraria;

USE livraria;

CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    telefone VARCHAR(20),
    email VARCHAR(255) NOT NULL
);

INSERT INTO usuarios (nome, telefone, email) VALUES
('João', '123-456-7890', 'joao@email.com'),
('Maria', '987-654-3210', 'maria@email.com');
