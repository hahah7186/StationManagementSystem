/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 100416
 Source Host           : localhost:3306
 Source Schema         : sm_system

 Target Server Type    : MySQL
 Target Server Version : 100416
 File Encoding         : 65001

 Date: 06/12/2020 15:27:09
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sm_delivery station
-- ----------------------------
DROP TABLE IF EXISTS `sm_delivery station`;
CREATE TABLE `sm_delivery station`  (
  `id` int(10) NOT NULL COMMENT 'id',
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'name',
  `identity_card` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Id card number',
  `phone_number` int(11) NULL DEFAULT NULL COMMENT 'phone number',
  `entry_time` datetime(6) NULL DEFAULT NULL COMMENT 'entrance time',
  `exit_time` datetime(6) NULL DEFAULT NULL COMMENT 'exit time',
  `cur_status` tinyint(1) NULL DEFAULT NULL COMMENT 'current status',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sm_user
-- ----------------------------
DROP TABLE IF EXISTS `sm_user`;
CREATE TABLE `sm_user`  (
  `id` int(5) NOT NULL COMMENT 'id',
  `user_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sm_user
-- ----------------------------
INSERT INTO `sm_user` VALUES (1, 'admin', '123456');

SET FOREIGN_KEY_CHECKS = 1;
