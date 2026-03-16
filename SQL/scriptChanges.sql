USE db_clientlab;
ALTER TABLE tb_vendas
ADD COLUMN tipo VARCHAR(2) NOT NULL AFTER data_hora_venda;