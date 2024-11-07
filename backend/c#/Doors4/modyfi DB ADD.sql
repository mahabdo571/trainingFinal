--ALTER TABLE WingAdvanced
--ADD KantA int NULL,
--KantB int NULL,
--;
ALTER TABLE WingLock
ADD UNIQUE (WingID);

ALTER TABLE Settings
	ADD StickerAmountPerDoor_Frame tinyint NULL,
	ADD StickerAmountPerDoor_F tinyint NULL,
	ADD StickerAmountPerDoor_A tinyint NULL,
	ADD StickerAmountPerDoor_Alpha tinyint NULL,
	ADD StickerAmountPerDoor_Windo tinyint NULL,
	ADD StickerAmountPerDoor_Tris tinyint NULL,
	ADD PaperAmountPerDoor_Frame tinyint NULL,
	ADD PaperAmountPerDoor_F tinyint NULL,
	ADD PaperAmountPerDoor_A tinyint NULL,
	ADD PaperAmountPerDoor_Alpha tinyint NULL,
	ADD PaperAmountPerDoor_Windo tinyint NULL,
	ADD PaperAmountPerDoor_Tris tinyint NULL;


