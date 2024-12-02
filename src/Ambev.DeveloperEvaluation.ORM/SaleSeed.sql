

-- Categorias
INSERT INTO public."Categorys" ("Id", "Code", "Name")

VALUES
  ('a7f3b8c8-1a9c-4c4f-9f4c-e7f0a1e0f4ab', 1, 'Refrigerantes'),
  ('b5d7c72b-0f84-45c5-8b79-3f4e0d1d6c73', 2, 'Sucos'),
  ('d0a67a0b-7aef-4b06-9c3b-c8eaf2da2fcb', 3, 'Águas');

-- Produtos 

  INSERT INTO public."Products" ("Id", "Name", "Price", "StockQuantity", "CategoryId", "Description")
VALUES
  ('b15e60a9-48e6-4f80-b823-4fa0e29d85b1', 'Coca-Cola 2L', 5, 150, 'a7f3b8c8-1a9c-4c4f-9f4c-e7f0a1e0f4ab', 'Coca-Cola 2L'),
  ('c27e53ad-4e94-4332-bc7d-5c4c6d29a9a6', 'Fanta Laranja 2L', 4, 100, 'a7f3b8c8-1a9c-4c4f-9f4c-e7f0a1e0f4ab', 'Fanta Laranja 2L'),
  ('d973c1f7-7b0f-44cc-9e5f-6b2ab9603f82', 'Sprite 2L', 4, 120, 'a7f3b8c8-1a9c-4c4f-9f4c-e7f0a1e0f4ab', 'Sprite 2L');


INSERT INTO public."Products" ("Id", "Name", "Price", "StockQuantity", "CategoryId", "Description")
VALUES
  ('a74b659f-1c0b-43d1-bce0-307937bba426', 'Suco de Laranja 1L', 3, 200, 'b5d7c72b-0f84-45c5-8b79-3f4e0d1d6c73', 'Suco natural de Laranja 1L'),
  ('f4b94b9e-bc7f-48a6-b728-1c631bf4ff30', 'Suco de Uva 1L', 4, 150, 'b5d7c72b-0f84-45c5-8b79-3f4e0d1d6c73', 'Suco natural de Uva 1L'),
  ('f5d7b2ac-35da-470b-8b92-7e3f01de6e45', 'Suco de Abacaxi 1L', 4, 120, 'b5d7c72b-0f84-45c5-8b79-3f4e0d1d6c73', 'Suco natural de Abacaxi 1L');
  
INSERT INTO public."Products" ("Id", "Name", "Price", "StockQuantity", "CategoryId", "Description")
VALUES
  ('d8773b1b-8e47-4676-b20d-620efcc3f3fc', 'Água Mineral 500ml', 2, 250, 'd0a67a0b-7aef-4b06-9c3b-c8eaf2da2fcb', 'Água Mineral 500ml'),
  ('63a6f5c7-4799-4f9e-b6d5-87c3e45bdb55', 'Água com Gás 500ml', 2, 200, 'd0a67a0b-7aef-4b06-9c3b-c8eaf2da2fcb', 'Água com Gás 500ml'),
  ('1f582b90-5d8d-475d-a5b3-cbcbf98333f5', 'Água Mineral 1L', 3, 180, 'd0a67a0b-7aef-4b06-9c3b-c8eaf2da2fcb', 'Água Mineral 1L');


-- Companinhas
  INSERT INTO public."Companys" ("Id", "Name", "TaxId", "Address", "IsHeadOffice", "HeadOfficeId")
VALUES
  ('f72b0b3f-8b1c-4d56-a19f-21b88bbebf7b', 'Ambev S.A.', '06091757000123', 'Rua dos Três Irmãos, 10 - São Paulo, SP', true, null),
  ('e39249ac-bd2a-4c38-b6c9-3b4477c04b9e', 'Ambev Filial Rio de Janeiro', '06091757000212', 'Avenida Presidente Vargas, 1000 - Rio de Janeiro, RJ', false, 'f72b0b3f-8b1c-4d56-a19f-21b88bbebf7b');