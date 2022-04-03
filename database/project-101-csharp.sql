/*
 Navicat Premium Data Transfer

 Source Server         : pg_localhost
 Source Server Type    : PostgreSQL
 Source Server Version : 110004
 Source Host           : localhost:5433
 Source Catalog        : project_101_csharp
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 110004
 File Encoding         : 65001

 Date: 03/04/2022 19:35:58
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS "public"."__EFMigrationsHistory";
CREATE TABLE "public"."__EFMigrationsHistory" (
  "MigrationId" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "ProductVersion" varchar(32) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20220214110322_ResetMigrations', '5.0.10');

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS "public"."category";
CREATE TABLE "public"."category" (
  "id" uuid NOT NULL,
  "name" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "created_at" timestamp(6) NOT NULL,
  "updated_at" timestamp(6) NOT NULL
)
;

-- ----------------------------
-- Records of category
-- ----------------------------
INSERT INTO "public"."category" VALUES ('06867776-b52c-4a85-8815-14ee1552a559', 'Camisetas', '2022-02-14 08:05:56.281231', '2022-02-14 08:05:56.281231');
INSERT INTO "public"."category" VALUES ('18e5b82c-6c4c-42ef-ab9f-5f142ecd663e', 'Canecas', '2022-02-14 08:05:56.292126', '2022-02-14 08:05:56.292126');
INSERT INTO "public"."category" VALUES ('e55d2134-b9ae-4921-bf05-b084e29248e1', 'Adeviso', '2022-02-14 08:05:56.293571', '2022-02-14 08:05:56.293571');
INSERT INTO "public"."category" VALUES ('d122b934-a80b-496b-9f01-08c9133aecc3', 'Sílvia39', '2022-02-20 14:08:35.085905', '2022-02-20 14:08:35.086937');
INSERT INTO "public"."category" VALUES ('dfe9fd93-451e-4287-89df-8a9573e85818', 'Sirineu.Franco EDITADO', '2022-02-20 14:09:17.395483', '2022-02-20 14:09:54.555195');
INSERT INTO "public"."category" VALUES ('2e2e8bd0-5dd8-448e-ab29-762050acead7', 'Ladislau86 EDITADO', '2022-02-20 14:11:11.295861', '2022-02-20 14:11:21.071226');
INSERT INTO "public"."category" VALUES ('ad3e9c68-4bf4-4df5-94ac-69cff9b70b7c', 'Norberto.Braga95 EDITADO', '2022-02-20 14:11:24.767975', '2022-02-20 14:11:27.435636');
INSERT INTO "public"."category" VALUES ('47a8edd2-5b52-432e-a319-a2a20bb6e9d8', 'Pablo48 EDITADO', '2022-02-20 14:20:16.568837', '2022-02-20 14:24:05.980656');
INSERT INTO "public"."category" VALUES ('c8bff8c3-7895-4d4c-abef-2aaddd9efaeb', 'Feliciano41 EDITADO', '2022-02-20 14:24:11.08882', '2022-02-20 14:29:35.318403');
INSERT INTO "public"."category" VALUES ('bde735f1-1613-4b88-b186-8e86914b93f3', 'Felícia_Souza EDITADO', '2022-02-20 15:05:56.857382', '2022-02-20 15:06:01.806253');
INSERT INTO "public"."category" VALUES ('d2387599-efbc-4b64-8ffb-324b4a75ea38', 'Yango.Oliveira', '2022-02-20 15:09:37.458441', '2022-02-20 15:09:37.458441');
INSERT INTO "public"."category" VALUES ('6d7546a7-8368-441e-bfd4-2ad165aeb1bb', 'Isabela39 EDITADO', '2022-02-20 15:09:40.373876', '2022-02-20 15:09:42.938248');
INSERT INTO "public"."category" VALUES ('42c76441-2bec-4327-ad6d-4d299caf7413', 'César.Souza', '2022-02-20 15:09:48.581167', '2022-02-20 15:09:48.581167');
INSERT INTO "public"."category" VALUES ('99ea6161-e702-4ff1-b8b1-32c31acc1a5a', 'Salvador5', '2022-02-20 15:12:36.936517', '2022-02-20 15:12:36.936517');
INSERT INTO "public"."category" VALUES ('3f07c601-3d55-4f5c-8c43-69a7ad4ee0b8', 'Janaína_Saraiva', '2022-02-20 15:12:41.617198', '2022-02-20 15:12:41.617198');
INSERT INTO "public"."category" VALUES ('6fffb4f5-73bb-4fbd-9bbb-12c087b49758', 'Ígor.Batista EDITADO', '2022-02-20 15:14:26.580459', '2022-02-20 15:14:29.858075');
INSERT INTO "public"."category" VALUES ('a03943ea-d618-4c83-82cb-f3979df92f38', 'Meire85', '2022-02-20 15:15:06.781387', '2022-02-20 15:15:06.781387');

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS "public"."product";
CREATE TABLE "public"."product" (
  "id" uuid NOT NULL,
  "name" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "description" varchar(256) COLLATE "pg_catalog"."default" NOT NULL,
  "active" bool NOT NULL,
  "value" numeric NOT NULL,
  "quantity" int4 NOT NULL,
  "image" text COLLATE "pg_catalog"."default",
  "created_at" timestamp(6) NOT NULL,
  "updated_at" timestamp(6) NOT NULL,
  "category_id" uuid NOT NULL
)
;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO "public"."product" VALUES ('0a988a84-3a2e-41bb-b8d7-7fb16a48cad0', 'Caneca Turn Coffe In Code', 'Descrição', 't', 15, 100, 'caneca3.jpg', '2021-02-27 17:10:21.116423', '2021-02-27 17:10:21.116423', '18e5b82c-6c4c-42ef-ab9f-5f142ecd663e');
INSERT INTO "public"."product" VALUES ('399a4305-1172-433a-891b-e0ac3857cde0', 'Caneca No Coffe No Code', 'Descrição', 't', 30, 100, 'caneca4.jpg', '2021-02-27 17:10:21.116423', '2021-02-27 17:10:21.116423', '18e5b82c-6c4c-42ef-ab9f-5f142ecd663e');
INSERT INTO "public"."product" VALUES ('82e966fe-806e-4395-97af-20bcf4f31733', 'Camiseta Debugar Preta', 'Descrição', 't', 110, 100, 'camiseta4.jpg', '2021-02-27 00:00:00', '2021-02-27 00:00:00', '06867776-b52c-4a85-8815-14ee1552a559');
INSERT INTO "public"."product" VALUES ('c498acc1-b622-4507-b3ff-64084325635e', 'Camiseta Code Life Preta', 'Descrição', 't', 90, 100, 'camiseta2.jpg', '2021-02-27 00:00:00', '2021-02-27 00:00:00', '06867776-b52c-4a85-8815-14ee1552a559');
INSERT INTO "public"."product" VALUES ('06867776-b52c-4a85-8815-14ee1552a559', 'Camiseta Sofware Developer', 'Descrição', 't', 100, 100, 'camiseta1.jpg', '2021-02-27 17:10:21.116423', '2021-02-27 17:10:21.116423', '06867776-b52c-4a85-8815-14ee1552a559');
INSERT INTO "public"."product" VALUES ('09c0e6b1-4763-4c77-bb92-ee3f68f8995e', 'Camiseta Code Life Cinza', 'Descrição', 't', 80, 100, 'camiseta3.jpg', '2021-02-27 17:08:52.913199', '2021-02-27 17:08:52.913199', '06867776-b52c-4a85-8815-14ee1552a559');
INSERT INTO "public"."product" VALUES ('55c0eb46-8eee-441d-afc6-a8ba3d2881df', 'Caneca Start Bugs', 'Descrição', 't', 25, 100, 'caneca1.jpg', '2021-02-27 17:10:21.116423', '2021-02-27 17:10:21.116423', '18e5b82c-6c4c-42ef-ab9f-5f142ecd663e');
INSERT INTO "public"."product" VALUES ('ac6deb27-e7c9-4169-99f9-787b28283573', 'Caneca Programmer Code', 'Descrição', 't', 15, 100, 'caneca2.jpg', '2021-02-27 17:14:35.909087', '2021-02-27 17:14:35.909087', '18e5b82c-6c4c-42ef-ab9f-5f142ecd663e');

-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE "public"."__EFMigrationsHistory" ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");

-- ----------------------------
-- Primary Key structure for table category
-- ----------------------------
ALTER TABLE "public"."category" ADD CONSTRAINT "category_pk" PRIMARY KEY ("id");

-- ----------------------------
-- Indexes structure for table product
-- ----------------------------
CREATE INDEX "IX_product_category_id" ON "public"."product" USING btree (
  "category_id" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table product
-- ----------------------------
ALTER TABLE "public"."product" ADD CONSTRAINT "product_pk" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table product
-- ----------------------------
ALTER TABLE "public"."product" ADD CONSTRAINT "product_category_id_fk" FOREIGN KEY ("category_id") REFERENCES "public"."category" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
