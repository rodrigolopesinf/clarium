INSERT INTO Maquina(IdModelo, IdStatus, NumeroIdentificacao, Voltagem, Observacao, DataAquisicao, 
IdUsuarioCriacao, DataHoraCriacao, Ativo)
SELECT G03_ID_TIPO_MAQUINA, 4, G11_NR_SERIAL_MAQUINA, G11_NR_VOLTAGEM, UPPER(G11_TX_OBSERVACAO), G11_DT_COMPRA, 
1, GETDATE(), 1 
FROM [VC_Gestao_Maquinas_Cafe].dbo.GMC_G11_MAQUINAS



