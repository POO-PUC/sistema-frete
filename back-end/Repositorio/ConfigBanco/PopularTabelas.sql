-- Populando a tabela Estado
INSERT INTO Estado (id_estado, nome_estado, uf, icms_local, icms_outro_uf) VALUES
(1, 'Goiás', 'GO', 17.00, 12.00),
(2, 'São Paulo', 'SP', 18.00, 12.00),
(3, 'Minas Gerais', 'MG', 18.00, 12.00);

-- Populando a tabela Cidade
INSERT INTO Cidade (id_cidade, nome_cidade, id_estado, valor) VALUES
(1, 'Goiânia', 1, 500.00),
(2, 'Anápolis', 1, 300.00),
(3, 'Aparecida de Goiânia', 1, 400.00),
(4, 'São Paulo', 2, 800.00),
(5, 'Campinas', 2, 600.00),
(6, 'Belo Horizonte', 3, 700.00),
(7, 'Uberlândia', 3, 500.00);

-- Populando a tabela Cliente
INSERT INTO Cliente (cod_cliente, endereco, telefone, data_inscricao) VALUES
(1, 'Rua 1, Goiânia', '62988887777', '2023-01-01'),
(2, 'Rua 2, Anápolis', '62988886666', '2023-02-01'),
(3, 'Av. Paulista, São Paulo', '11988887777', '2023-03-01'),
(4, 'Rua A, Belo Horizonte', '31988885555', '2023-04-01'),
(5, 'Rua B, Uberlândia', '34988884444', '2023-05-01'),
(6, 'Rua Nova, Goiânia', '62999991111', '2023-06-01'),
(7, 'Rua Central, Anápolis', '62977772222', '2023-07-01'),
(8, 'Rua Velha, São Paulo', '11988880000', '2023-08-01'),
(9, 'Av. Central, Belo Horizonte', '31999992222', '2023-09-01'),
(10, 'Rua das Flores, Uberlândia', '34955556666', '2023-10-01'),
(11, 'Rua Industrial, Goiânia', '62988880000', '2023-11-01'),
(12, 'Rua Comercial, Anápolis', '62966665555', '2023-12-01');

-- Populando a tabela Funcionario
INSERT INTO Funcionario (id_funcionario, nome_funcionario, num_registro) VALUES
(1, 'João Silva', 1001),
(2, 'Maria Oliveira', 1002),
(3, 'Pedro Santos', 1003),
(4, 'Ana Lima', 1004),
(5, 'Carlos Souza', 1005);

-- Populando a tabela PessoaJuridica
INSERT INTO PessoaJuridica (cod_PessoaJuridica, razao_social, inscricao_estadual, cnpj, eh_representante) VALUES
(11, 'Empresa Alpha LTDA', '123456789', '00.123.456/0001-01', TRUE),
(12, 'Beta Comércio SA', '987654321', '11.987.654/0001-02', FALSE);

-- Populando a tabela PessoaFisica
INSERT INTO PessoaFisica (cod_PessoaFisica, nome_cliente, cpf, representante) VALUES
(6, 'João da Silva', '111.222.333-44', 11),
(7, 'Maria Oliveira', '222.333.444-55', 11),
(8, 'Carlos Souza', '333.444.555-66', NULL),
(9, 'Ana Lima', '444.555.666-77', 11),
(10, 'Paulo Mendes', '555.666.777-88', 11);

-- Populando a tabela Frete
INSERT INTO Frete (id_frete, peso, valor, icms, pedagio, data_frete, id_origem, id_destino, id_remetente, id_destinatario, id_funcionario, quem_paga, num_conhecimento) VALUES
(1, 100.50, 1200.00, 204.00, 50.00, '2024-01-15', 1, 2, 6, 7, 1, 'Remetente', 'CN123456'),
(2, 200.75, 1800.00, 306.00, 75.00, '2024-01-16', 2, 1, 7, 6, 2, 'Destinatário', 'CN123457'),
(3, 150.30, 1600.00, 288.00, 60.00, '2024-01-17', 4, 5, 8, 9, 3, 'Remetente', 'CN123458'),
(4, 250.00, 2000.00, 360.00, 100.00, '2024-01-18', 5, 4, 9, 8, 4, 'Destinatário', 'CN123459'),
(5, 300.00, 2500.00, 450.00, 125.00, '2024-01-19', 6, 7, 10, 9, 5, 'Remetente', 'CN123460'),
(6, 120.00, 1100.00, 198.00, 40.00, '2024-01-20', 7, 6, 10, 8, 1, 'Remetente', 'CN123461'),
(7, 100.00, 1050.00, 189.00, 35.00, '2024-01-21', 1, 4, 6, 9, 2, 'Remetente', 'CN123462'),
(8, 220.00, 2300.00, 414.00, 95.00, '2024-01-22', 3, 5, 8, 7, 3, 'Destinatário', 'CN123463'),
(9, 80.00, 950.00, 171.00, 30.00, '2024-01-23', 2, 6, 7, 5, 4, 'Remetente', 'CN123464'),
(10, 140.00, 1450.00, 261.00, 45.00, '2024-01-24', 4, 7, 9, 6, 5, 'Destinatário', 'CN123465'),
(15, 100.50, 1200.00, 204.00, 50.00, '2024-01-15', 1, 2, 11, 7, 1, 'Remetente', 'CN123456'),
(16, 200.75, 1800.00, 306.00, 75.00, '2024-01-16', 2, 1, 12, 6, 2, 'Destinatário', 'CN123457');