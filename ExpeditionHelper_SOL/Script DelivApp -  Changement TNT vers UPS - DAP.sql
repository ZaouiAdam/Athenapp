/*************************** Passage des �tapes TNT en UPS ****************************/
USE DelivApp
GO

UPDATE TB_ETAPE
SET Texte = 'Transporteur UPS � notre compte si colis < 25kg ou Dachser si colis > 25 kg'
WHERE Texte like '%Transporteur UPS � notre compte si colis < 25kg ou Dachser si colis > 25 kg%'
AND IdIncoterm = (SELECT Id FROM TB_INCOTERM WHERE Nom = 'DAP');

UPDATE TB_ETAPE
SET Texte = 'Si colis< 25Kgs Utilisez transporteur UPS � notre compte'
WHERE Texte like '%Si colis< 25Kgs Utilisez transporteur TNT � notre compte%'
AND IdIncoterm = (SELECT Id FROM TB_INCOTERM WHERE Nom = 'DAP');