/*
Navicat MySQL Data Transfer

Source Server         : QUESTION_BANK
Source Server Version : 50511
Source Host           : localhost:3306
Source Database       : db_question_bank

Target Server Type    : MYSQL
Target Server Version : 50511
File Encoding         : 65001

Date: 2014-05-19 00:16:54
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_authority`
-- ----------------------------
DROP TABLE IF EXISTS `t_authority`;
CREATE TABLE `t_authority` (
  `AUTHORITY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AUTHORITY_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`AUTHORITY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_authority
-- ----------------------------
INSERT INTO `t_authority` VALUES ('1', 'Question Bank Admin');
INSERT INTO `t_authority` VALUES ('2', 'Lesson Admin');
INSERT INTO `t_authority` VALUES ('3', 'Exam&Question Admin');
INSERT INTO `t_authority` VALUES ('4', 'Exam&Question Viewer');

-- ----------------------------
-- Table structure for `t_department`
-- ----------------------------
DROP TABLE IF EXISTS `t_department`;
CREATE TABLE `t_department` (
  `DEPARTMENT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DEPARTMENT_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`DEPARTMENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_department
-- ----------------------------
INSERT INTO `t_department` VALUES ('1', 'Computer Science Department');
INSERT INTO `t_department` VALUES ('2', 'Chemistry Science Department');
INSERT INTO `t_department` VALUES ('3', 'Physical Training Department');
INSERT INTO `t_department` VALUES ('4', 'Construction Department');
INSERT INTO `t_department` VALUES ('5', 'Historical Sciences Department');

-- ----------------------------
-- Table structure for `t_exam`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam`;
CREATE TABLE `t_exam` (
  `EXAM_ID` int(11) NOT NULL AUTO_INCREMENT,
  `EXAM_NAME` varchar(100) NOT NULL,
  `LESSON_ID` int(11) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  `USER_ID` int(11) NOT NULL,
  `ASKED_YEAR` varchar(50) NOT NULL,
  `EXAM_QUESTION_FINISHED` varchar(1) NOT NULL,
  PRIMARY KEY (`EXAM_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam
-- ----------------------------
INSERT INTO `t_exam` VALUES ('13', ' wqغذن غنن', '6', '2014-05-08 23:23:59', '1', '2014', 'N');
INSERT INTO `t_exam` VALUES ('15', 'Network Exam', '3', '2014-05-09 15:49:01', '1', '2014', 'Y');
INSERT INTO `t_exam` VALUES ('16', 'aaa', '3', '2014-05-15 22:54:52', '1', '2014', 'Y');

-- ----------------------------
-- Table structure for `t_exam_group`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam_group`;
CREATE TABLE `t_exam_group` (
  `EXAM_GROUP_ID` int(11) NOT NULL AUTO_INCREMENT,
  `EXAM_GROUP_NAME` char(1) NOT NULL,
  PRIMARY KEY (`EXAM_GROUP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam_group
-- ----------------------------
INSERT INTO `t_exam_group` VALUES ('1', 'A');
INSERT INTO `t_exam_group` VALUES ('2', 'B');
INSERT INTO `t_exam_group` VALUES ('3', 'C');
INSERT INTO `t_exam_group` VALUES ('4', 'D');

-- ----------------------------
-- Table structure for `t_exam_question`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam_question`;
CREATE TABLE `t_exam_question` (
  `EXAM_QUESTION_ID` int(11) NOT NULL AUTO_INCREMENT,
  `EXAM_ID` int(11) NOT NULL,
  `QUESTION_ID` int(11) NOT NULL,
  `QUESTION_SUCCESS_RATE` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`EXAM_QUESTION_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=233 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam_question
-- ----------------------------
INSERT INTO `t_exam_question` VALUES ('219', '16', '3', null);
INSERT INTO `t_exam_question` VALUES ('220', '15', '111', '');
INSERT INTO `t_exam_question` VALUES ('221', '15', '105', '');
INSERT INTO `t_exam_question` VALUES ('222', '15', '6', '');
INSERT INTO `t_exam_question` VALUES ('223', '15', '110', '');
INSERT INTO `t_exam_question` VALUES ('224', '15', '3', '');
INSERT INTO `t_exam_question` VALUES ('225', '15', '1', '');
INSERT INTO `t_exam_question` VALUES ('226', '15', '108', '');
INSERT INTO `t_exam_question` VALUES ('227', '15', '107', '');
INSERT INTO `t_exam_question` VALUES ('228', '15', '9', '');
INSERT INTO `t_exam_question` VALUES ('229', '15', '10', '');
INSERT INTO `t_exam_question` VALUES ('230', '15', '109', '');
INSERT INTO `t_exam_question` VALUES ('231', '15', '8', '');
INSERT INTO `t_exam_question` VALUES ('232', '15', '112', '');

-- ----------------------------
-- Table structure for `t_exam_question_template`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam_question_template`;
CREATE TABLE `t_exam_question_template` (
  `EXAM_QUESTION_TEMPLATE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `EXAM_TEMPLATE_ID` int(11) NOT NULL,
  `EXAM_QUESTION_ID` int(11) NOT NULL,
  `EXAM_QUESTION_ORDER` int(11) NOT NULL,
  PRIMARY KEY (`EXAM_QUESTION_TEMPLATE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=317 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam_question_template
-- ----------------------------

-- ----------------------------
-- Table structure for `t_exam_sub_top_que_count`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam_sub_top_que_count`;
CREATE TABLE `t_exam_sub_top_que_count` (
  `exam_sub_top_que_count_id` int(11) NOT NULL AUTO_INCREMENT,
  `exam_id` int(11) NOT NULL,
  `lesson_sub_topic_id` int(11) NOT NULL,
  `question_difficulty_id` int(11) NOT NULL,
  `question_count` int(11) NOT NULL,
  `question_type_id` int(11) NOT NULL,
  PRIMARY KEY (`exam_sub_top_que_count_id`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam_sub_top_que_count
-- ----------------------------
INSERT INTO `t_exam_sub_top_que_count` VALUES ('6', '13', '5', '4', '3', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('10', '13', '7', '2', '2', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('11', '13', '2', '2', '5', '2');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('13', '13', '7', '3', '3', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('40', '15', '6', '2', '1', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('41', '15', '6', '1', '1', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('42', '15', '6', '2', '3', '2');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('43', '15', '6', '3', '3', '1');
INSERT INTO `t_exam_sub_top_que_count` VALUES ('44', '15', '6', '3', '5', '2');

-- ----------------------------
-- Table structure for `t_exam_template`
-- ----------------------------
DROP TABLE IF EXISTS `t_exam_template`;
CREATE TABLE `t_exam_template` (
  `EXAM_TEMPLATE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `EXAM_GROUP_ID` int(11) NOT NULL,
  `EXAM_ID` int(11) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  PRIMARY KEY (`EXAM_TEMPLATE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_exam_template
-- ----------------------------

-- ----------------------------
-- Table structure for `t_lesson`
-- ----------------------------
DROP TABLE IF EXISTS `t_lesson`;
CREATE TABLE `t_lesson` (
  `LESSON_ID` int(11) NOT NULL AUTO_INCREMENT,
  `LESSON_NAME` varchar(50) NOT NULL,
  `LESSON_CODE` varchar(20) DEFAULT NULL,
  `DEPARTMENT_ID` int(11) NOT NULL,
  `LESSON_CLASS` varchar(20) NOT NULL,
  `LESSON_TERM` varchar(20) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  PRIMARY KEY (`LESSON_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_lesson
-- ----------------------------
INSERT INTO `t_lesson` VALUES ('3', 'Network Analysis', 'NA1', '1', '2', '1', '2014-05-01 16:08:32');
INSERT INTO `t_lesson` VALUES ('5', 'Web Design-2', 'WD2', '1', '1', '2', '2014-05-01 16:25:59');
INSERT INTO `t_lesson` VALUES ('6', 'Web Design-1', 'WD1', '1', '1', '1', '2014-05-01 16:33:14');
INSERT INTO `t_lesson` VALUES ('7', 'صسی قبر', 'ثی1 تال5', '1', '1', '1', '2014-05-15 09:28:05');

-- ----------------------------
-- Table structure for `t_lesson_sub_topic`
-- ----------------------------
DROP TABLE IF EXISTS `t_lesson_sub_topic`;
CREATE TABLE `t_lesson_sub_topic` (
  `LESSON_SUB_TOPIC_ID` int(11) NOT NULL AUTO_INCREMENT,
  `LESSON_SUB_TOPIC_NAME` varchar(50) NOT NULL,
  `LESSON_SUB_TOPIC_CODE` varchar(20) NOT NULL,
  `LESSON_SUBJECT_ID` int(11) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  PRIMARY KEY (`LESSON_SUB_TOPIC_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_lesson_sub_topic
-- ----------------------------
INSERT INTO `t_lesson_sub_topic` VALUES ('2', 'Styles', 'WD1HB1S1', '3', '2014-05-02 23:07:07');
INSERT INTO `t_lesson_sub_topic` VALUES ('5', 'images\"\"', 'WD1HB1i', '3', '2014-05-03 08:27:47');
INSERT INTO `t_lesson_sub_topic` VALUES ('6', 'Topologies', 'NA1LAN1T1', '2', '2014-05-04 16:25:40');
INSERT INTO `t_lesson_sub_topic` VALUES ('7', 'table rows', 'WD1T1tr1', '4', '2014-05-09 00:09:40');
INSERT INTO `t_lesson_sub_topic` VALUES ('8', 'Framerk contruction1', 'WD2.nf1Fc1', '6', '2014-05-09 13:07:45');

-- ----------------------------
-- Table structure for `t_lesson_subject`
-- ----------------------------
DROP TABLE IF EXISTS `t_lesson_subject`;
CREATE TABLE `t_lesson_subject` (
  `LESSON_SUBJECT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `LESSON_SUBJECT_NAME` varchar(50) NOT NULL,
  `LESSON_SUBJECT_CODE` varchar(20) NOT NULL,
  `LESSON_ID` int(11) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  PRIMARY KEY (`LESSON_SUBJECT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_lesson_subject
-- ----------------------------
INSERT INTO `t_lesson_subject` VALUES ('2', 'Local Area Network-1', 'NA1LAN1', '3', '2014-05-02 10:02:17');
INSERT INTO `t_lesson_subject` VALUES ('3', 'HTML Body-1', 'WD1HB1', '6', '2014-05-02 10:02:57');
INSERT INTO `t_lesson_subject` VALUES ('4', 'Tables-1', 'WD1T1', '6', '2014-05-02 10:03:29');
INSERT INTO `t_lesson_subject` VALUES ('5', 'Html coding', 'WD1HC1', '6', '2014-05-04 16:48:18');
INSERT INTO `t_lesson_subject` VALUES ('6', '.net framework', 'WD2.nf1', '5', '2014-05-09 13:06:30');

-- ----------------------------
-- Table structure for `t_log`
-- ----------------------------
DROP TABLE IF EXISTS `t_log`;
CREATE TABLE `t_log` (
  `LOG_ID` int(11) NOT NULL AUTO_INCREMENT,
  `LOG_CONTENT` varchar(500) NOT NULL,
  `USER_ID` int(11) NOT NULL,
  `LOG_DATE` datetime NOT NULL,
  `HOST_IP` varchar(15) NOT NULL,
  PRIMARY KEY (`LOG_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=826 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_log
-- ----------------------------
INSERT INTO `t_log` VALUES ('1', 'User has logged on.', '1', '2014-04-24 15:43:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('2', 'User has logged out.', '1', '2014-04-24 15:43:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('3', 'User has logged on.', '1', '2014-04-24 15:50:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('4', 'User has logged on.', '1', '2014-04-24 15:52:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('5', 'User has logged on.', '1', '2014-04-24 15:55:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('6', 'User has logged on.', '1', '2014-04-24 15:59:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('7', 'User has logged on.', '1', '2014-04-24 16:01:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('8', 'User has logged on.', '1', '2014-04-24 16:01:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('9', 'User has logged on.', '1', '2014-04-24 16:10:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('10', 'User has logged on.', '1', '2014-04-24 22:24:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('11', 'User has logged on.', '1', '2014-04-24 22:26:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('12', 'User has logged on.', '1', '2014-04-24 22:30:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('13', 'User has logged out.', '1', '2014-04-24 22:32:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('14', 'User has logged on.', '1', '2014-04-24 22:32:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('15', 'User has logged out.', '1', '2014-04-24 22:32:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('16', 'User has logged on.', '1', '2014-04-24 22:32:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('17', 'User has logged on.', '1', '2014-04-24 22:34:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('18', 'User has logged out.', '1', '2014-04-24 22:35:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('19', 'User has logged on.', '1', '2014-04-24 22:40:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('20', 'User has logged on.', '1', '2014-04-24 22:42:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('21', 'User has logged on.', '1', '2014-04-24 22:51:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('22', 'User has logged on.', '1', '2014-04-24 22:54:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('23', 'User has logged out.', '1', '2014-04-24 22:56:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('24', 'User has logged on.', '1', '2014-04-25 15:00:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('25', 'User has logged out.', '1', '2014-04-25 15:16:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('26', 'User has logged on.', '1', '2014-04-25 15:18:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('27', 'User has logged on.', '1', '2014-04-25 15:20:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('28', 'User has logged on.', '1', '2014-04-25 19:23:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('29', 'User has logged out.', '1', '2014-04-25 19:59:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('30', 'User has logged on.', '1', '2014-04-25 21:18:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('31', 'User has logged out.', '1', '2014-04-25 21:19:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('32', 'User has logged on.', '1', '2014-04-25 21:22:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('33', 'User has logged on.', '1', '2014-04-25 21:24:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('34', 'User has logged on.', '1', '2014-04-25 21:56:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('35', 'User has logged out.', '1', '2014-04-25 21:56:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('36', 'User has logged on.', '1', '2014-04-25 21:57:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('37', 'User has logged out.', '1', '2014-04-25 21:57:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('38', 'User has logged on.', '1', '2014-04-25 22:19:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('39', 'User has logged out.', '1', '2014-04-25 22:19:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('40', 'User has logged on.', '1', '2014-04-25 22:21:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('41', 'User has logged out.', '1', '2014-04-25 22:21:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('42', 'User has logged on.', '1', '2014-04-25 22:23:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('43', 'User has logged out.', '1', '2014-04-25 22:24:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('44', 'User has logged on.', '1', '2014-04-25 22:24:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('45', 'User has logged on.', '1', '2014-04-26 08:14:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('46', 'User has logged out.', '1', '2014-04-26 08:14:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('47', 'User has logged on.', '1', '2014-04-26 08:14:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('48', 'User has logged out.', '1', '2014-04-26 08:15:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('49', 'User has logged on.', '1', '2014-04-26 08:16:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('50', 'User has logged out.', '1', '2014-04-26 08:16:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('51', 'User has logged on.', '1', '2014-04-26 08:18:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('52', 'User has logged out.', '1', '2014-04-26 08:19:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('53', 'User has logged on.', '1', '2014-04-26 08:49:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('54', 'User has logged on.', '1', '2014-04-26 09:18:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('55', 'User has logged on.', '1', '2014-04-26 09:20:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('56', 'User has logged on.', '1', '2014-04-26 09:25:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('57', 'User has logged on.', '1', '2014-04-26 09:28:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('58', 'User has logged out.', '1', '2014-04-26 09:29:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('59', 'User has logged on.', '1', '2014-04-26 09:36:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('60', 'User has logged on.', '1', '2014-04-26 09:39:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('61', 'User has logged out.', '1', '2014-04-26 09:40:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('62', 'User has logged on.', '1', '2014-04-26 16:34:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('63', 'User has logged off.', '1', '2014-04-26 16:34:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('64', 'User has logged on.', '1', '2014-04-26 16:34:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('65', 'User has logged on.', '1', '2014-04-26 16:56:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('66', 'User has logged on.', '1', '2014-04-26 21:21:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('67', 'User has logged off.', '1', '2014-04-26 21:27:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('68', 'User has logged on.', '1', '2014-04-26 21:28:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('69', 'User has logged off.', '1', '2014-04-26 21:43:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('70', 'User has logged on.', '1', '2014-04-26 21:53:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('71', 'User has logged on.', '1', '2014-04-26 22:14:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('72', 'User has logged on.', '1', '2014-04-26 22:42:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('73', 'User has logged on.', '1', '2014-04-26 22:44:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('74', 'User has logged on.', '1', '2014-04-26 22:50:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('75', 'User has logged on.', '1', '2014-04-26 22:54:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('76', 'User has logged on.', '1', '2014-04-26 23:01:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('77', 'User has logged off.', '1', '2014-04-26 23:07:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('78', 'User has logged on.', '1', '2014-04-26 23:11:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('79', 'User has logged on.', '1', '2014-04-26 23:29:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('80', 'User has logged off.', '1', '2014-04-26 23:30:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('81', 'User has logged on.', '1', '2014-04-26 23:35:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('82', 'User has logged off.', '1', '2014-04-26 23:38:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('83', 'User has logged on.', '1', '2014-04-26 23:39:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('84', 'User has logged on.', '1', '2014-04-26 23:45:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('85', 'User has recorded new user account.', '1', '2014-04-26 23:46:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('86', 'User has recorded new user account.', '1', '2014-04-26 23:50:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('87', 'User has logged off.', '1', '2014-04-26 23:54:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('88', 'User has logged on.', '1', '2014-04-26 23:55:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('89', 'User has logged off.', '1', '2014-04-27 00:06:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('90', 'User has logged on.', '1', '2014-04-27 15:54:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('91', 'User has recorded a new user account.', '1', '2014-04-27 16:36:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('92', 'User has logged on.', '1', '2014-04-27 18:05:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('93', 'User has recorded a new user account.', '1', '2014-04-27 18:07:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('94', 'User has logged off.', '1', '2014-04-27 18:07:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('95', 'User has logged on.', '5', '2014-04-27 18:07:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('96', 'User has logged off.', '5', '2014-04-27 18:10:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('97', 'User has logged on.', '5', '2014-04-27 18:10:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('98', 'User has logged on.', '1', '2014-04-28 10:37:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('99', 'User has logged off.', '1', '2014-04-28 10:43:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('100', 'User has logged on.', '4', '2014-04-28 11:12:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('101', 'User has logged off.', '4', '2014-04-28 11:12:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('102', 'User has logged on.', '4', '2014-04-28 11:24:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('103', 'User has logged on.', '4', '2014-04-28 11:24:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('104', 'User has logged on.', '4', '2014-04-28 11:25:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('105', 'User has logged on.', '4', '2014-04-28 11:27:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('106', 'User has logged on.', '4', '2014-04-28 11:30:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('107', 'User has logged on.', '4', '2014-04-28 15:44:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('108', 'User has logged off.', '4', '2014-04-28 15:44:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('109', 'User has logged on.', '4', '2014-04-28 15:49:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('110', 'User has logged off.', '4', '2014-04-28 15:49:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('111', 'User has changed his\\her password and logged on to application.', '4', '2014-04-28 16:04:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('112', 'User has changed his\\her password and logged on to application.', '4', '2014-04-28 16:05:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('113', 'User has changed his\\her password and logged on to application.', '4', '2014-04-28 16:06:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('114', 'User has changed his\\her password and logged on to application.', '4', '2014-04-28 16:07:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('115', 'User has changed his\\her password and logged on to application.', '4', '2014-04-28 16:10:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('116', 'User has logged off.', '4', '2014-04-28 16:11:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('117', 'User has changed his\\her password and logged on to application.', '5', '2014-04-28 16:12:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('118', 'User has logged off.', '5', '2014-04-28 16:12:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('119', 'User has changed his\\her password and logged on to application.', '5', '2014-04-28 16:19:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('120', 'User has logged off.', '5', '2014-04-28 16:20:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('121', 'User has logged on.', '1', '2014-04-28 19:18:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('122', 'User has logged on.', '1', '2014-04-28 19:25:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('123', 'User has logged off.', '1', '2014-04-28 19:26:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('124', 'User has logged on.', '4', '2014-04-28 19:26:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('125', 'User has logged off.', '4', '2014-04-28 19:26:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('126', 'User has logged on.', '5', '2014-04-28 19:27:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('127', 'User has logged off.', '5', '2014-04-28 19:28:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('128', 'User has logged on.', '1', '2014-04-28 21:31:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('129', 'User has recorded a new user account.', '1', '2014-04-28 21:34:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('130', 'User has logged off.', '1', '2014-04-28 21:34:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('131', 'User has changed his\\her password and logged on to application.', '6', '2014-04-28 21:36:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('132', 'User has logged off.', '6', '2014-04-28 21:37:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('133', 'User has logged on.', '1', '2014-04-28 21:37:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('134', 'User has recorded a new user account.', '1', '2014-04-28 21:38:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('135', 'User has recorded a new user account.', '1', '2014-04-28 21:41:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('136', 'User has recorded a new user account.', '1', '2014-04-28 21:44:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('137', 'User has recorded a new user account.', '1', '2014-04-28 21:48:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('138', 'User has logged off.', '1', '2014-04-28 21:48:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('139', 'User has logged on.', '1', '2014-04-28 21:55:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('140', 'User has logged off.', '1', '2014-04-28 21:58:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('141', 'User has logged on.', '1', '2014-04-28 22:13:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('142', 'User has recorded a new user account.', '1', '2014-04-28 22:14:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('143', 'User has recorded a new user account.', '1', '2014-04-28 22:16:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('144', 'User has logged off.', '1', '2014-04-28 22:16:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('145', 'User has logged on.', '1', '2014-04-28 23:11:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('146', 'User has logged off.', '1', '2014-04-28 23:14:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('147', 'User has logged on.', '1', '2014-04-29 08:28:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('148', 'User has logged off.', '1', '2014-04-29 08:28:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('149', 'User has logged on.', '1', '2014-04-29 08:29:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('150', 'User has logged off.', '1', '2014-04-29 08:38:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('151', 'User has logged on.', '1', '2014-04-29 09:22:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('152', 'User has logged off.', '1', '2014-04-29 09:27:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('153', 'User has logged on.', '1', '2014-04-29 09:35:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('154', 'User has logged on.', '1', '2014-04-29 09:45:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('155', 'User has logged on.', '1', '2014-04-29 10:04:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('156', 'User has logged off.', '1', '2014-04-29 10:12:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('157', 'User has logged on.', '1', '2014-04-29 14:22:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('158', 'User has logged off.', '1', '2014-04-29 14:24:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('159', 'User has logged on.', '1', '2014-04-29 14:35:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('160', 'User has logged on.', '1', '2014-04-29 14:44:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('161', 'User has logged on.', '1', '2014-04-29 15:23:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('162', 'User has logged on.', '1', '2014-04-29 15:42:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('163', 'User has logged off.', '1', '2014-04-29 15:44:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('164', 'User has logged on.', '1', '2014-04-29 15:45:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('165', 'User has logged on.', '1', '2014-04-29 16:05:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('166', 'User has logged on.', '1', '2014-04-29 16:20:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('167', 'User has logged off.', '1', '2014-04-29 16:23:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('168', 'User has logged on.', '1', '2014-04-29 16:55:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('169', 'User has logged on.', '1', '2014-04-29 16:57:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('170', 'User has logged off.', '1', '2014-04-29 17:03:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('171', 'User has logged on.', '1', '2014-04-29 17:03:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('172', 'User has logged off.', '1', '2014-04-29 17:05:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('173', 'User has logged on.', '1', '2014-04-29 20:54:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('174', 'User has logged on.', '1', '2014-04-29 21:12:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('175', 'User has logged on.', '1', '2014-04-29 23:50:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('176', 'User has updated user account.', '1', '2014-04-30 00:02:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('177', 'User has updated user account.', '1', '2014-04-30 00:03:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('178', 'User has logged off.', '1', '2014-04-30 00:03:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('179', 'User has logged on.', '1', '2014-04-30 08:08:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('180', 'User has updated user account.', '1', '2014-04-30 08:10:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('181', 'User has updated user account.', '1', '2014-04-30 08:12:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('182', 'User has updated user password.', '1', '2014-04-30 08:21:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('183', 'User has logged off.', '1', '2014-04-30 08:22:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('184', 'User has logged on.', '1', '2014-04-30 08:26:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('185', 'User has logged off.', '1', '2014-04-30 08:27:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('186', 'User has logged on.', '1', '2014-04-30 08:27:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('187', 'User has logged on.', '1', '2014-04-30 08:28:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('188', 'User has logged on.', '1', '2014-04-30 08:39:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('189', 'User has updated user account.', '1', '2014-04-30 08:51:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('190', 'User has updated user account.', '1', '2014-04-30 08:52:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('191', 'User has updated user account.', '1', '2014-04-30 08:54:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('192', 'User has logged on.', '1', '2014-04-30 09:04:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('193', 'User has logged on.', '1', '2014-04-30 09:27:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('194', 'User has logged on.', '1', '2014-04-30 09:41:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('195', 'User has updated user account.', '1', '2014-04-30 09:44:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('196', 'User has updated user password.', '1', '2014-04-30 09:45:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('197', 'User has updated user password.', '1', '2014-04-30 09:47:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('198', 'User has updated user account.', '1', '2014-04-30 09:49:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('199', 'User has updated user account.', '1', '2014-04-30 10:07:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('200', 'User has logged off.', '1', '2014-04-30 10:07:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('201', 'User has logged on.', '1', '2014-04-30 15:11:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('202', 'User has logged off.', '1', '2014-04-30 15:25:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('203', 'User has logged on.', '1', '2014-04-30 16:46:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('204', 'User has recorded a new user account. Recorded new User\'s ID is 12', '1', '2014-04-30 16:48:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('205', 'User has updated user account. Updated User\'s ID is 12', '1', '2014-04-30 16:49:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('206', 'User has updated user password. Updated User\'s ID is 12', '1', '2014-04-30 16:51:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('207', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 1', '1', '2014-04-30 16:52:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('208', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 2', '1', '2014-04-30 16:54:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('209', 'User has logged off.', '1', '2014-04-30 16:54:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('210', 'User has logged on.', '1', '2014-05-01 11:49:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('211', 'User has logged off.', '1', '2014-05-01 11:55:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('212', 'User has logged on.', '1', '2014-05-01 16:05:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('213', 'User has updated Lesson. Updated Lesson\'s ID is 1', '1', '2014-05-01 16:06:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('214', 'User has updated Lesson. Updated Lesson\'s ID is 2', '1', '2014-05-01 16:07:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('215', 'User has updated Lesson. Updated Lesson\'s ID is 2', '1', '2014-05-01 16:07:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('216', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 3', '1', '2014-05-01 16:08:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('217', 'User has updated Lesson. Updated Lesson\'s ID is 2', '1', '2014-05-01 16:09:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('218', 'User has logged off.', '1', '2014-05-01 16:09:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('219', 'User has logged on.', '1', '2014-05-01 16:17:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('220', 'User has logged off.', '1', '2014-05-01 16:17:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('221', 'User has logged on.', '1', '2014-05-01 16:22:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('222', 'User has deleted Lesson. Deleted Lesson\'s ID is 2', '1', '2014-05-01 16:24:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('223', 'User has deleted Lesson. Deleted Lesson\'s ID is 1', '1', '2014-05-01 16:24:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('224', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 4', '1', '2014-05-01 16:25:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('225', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 5', '1', '2014-05-01 16:25:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('226', 'User has updated Lesson. Updated Lesson\'s ID is 4', '1', '2014-05-01 16:26:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('227', 'User has deleted Lesson. Deleted Lesson\'s ID is 4', '1', '2014-05-01 16:27:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('228', 'User has logged off.', '1', '2014-05-01 16:27:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('229', 'User has logged on.', '1', '2014-05-01 16:32:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('230', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 6', '1', '2014-05-01 16:33:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('231', 'User has logged off.', '1', '2014-05-01 16:41:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('232', 'User has logged on.', '1', '2014-05-01 16:43:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('233', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 7', '1', '2014-05-01 16:44:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('234', 'User has updated Lesson. Updated Lesson\'s ID is 7', '1', '2014-05-01 16:45:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('235', 'User has deleted Lesson. Deleted Lesson\'s ID is 7', '1', '2014-05-01 16:45:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('236', 'User has logged off.', '1', '2014-05-01 16:46:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('237', 'User has logged on.', '1', '2014-05-02 09:36:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('238', 'User has logged on.', '1', '2014-05-02 09:50:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('239', 'User has logged on.', '1', '2014-05-02 09:58:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('240', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 1', '1', '2014-05-02 10:00:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('241', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 2', '1', '2014-05-02 10:02:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('242', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 3', '1', '2014-05-02 10:02:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('243', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 4', '1', '2014-05-02 10:03:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('244', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 5', '1', '2014-05-02 10:03:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('245', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 6', '1', '2014-05-02 10:04:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('246', 'User has logged off.', '1', '2014-05-02 10:05:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('247', 'User has logged on.', '1', '2014-05-02 10:47:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('248', 'User has logged on.', '1', '2014-05-02 10:49:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('249', 'User has logged off.', '1', '2014-05-02 10:59:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('250', 'User has logged on.', '1', '2014-05-02 12:49:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('251', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 7', '1', '2014-05-02 12:50:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('252', 'User has logged on.', '1', '2014-05-02 12:51:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('253', 'User has updated Lesson Subject. Updated Lesson Subject\'s ID is ', '1', '2014-05-02 12:54:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('254', 'User has logged off.', '1', '2014-05-02 12:55:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('255', 'User has logged on.', '1', '2014-05-02 13:00:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('256', 'User has logged off.', '1', '2014-05-02 13:01:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('257', 'User has logged on.', '1', '2014-05-02 13:10:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('258', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is ', '1', '2014-05-02 13:10:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('259', 'User has logged off.', '1', '2014-05-02 13:11:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('260', 'User has logged on.', '1', '2014-05-02 22:51:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('261', 'User has logged on.', '1', '2014-05-02 22:57:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('262', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 1', '1', '2014-05-02 23:05:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('263', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 2', '1', '2014-05-02 23:07:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('264', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 3', '1', '2014-05-02 23:07:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('265', 'User has logged off.', '1', '2014-05-02 23:08:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('266', 'User has logged on.', '1', '2014-05-03 08:25:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('267', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 4', '1', '2014-05-03 08:26:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('268', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 5', '1', '2014-05-03 08:27:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('269', 'User has logged off.', '1', '2014-05-03 08:30:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('270', 'User has logged on.', '1', '2014-05-03 08:31:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('271', 'User has recorded a new lesson sub issue. Recorded new Lesson sub issue\'s ID is 6', '1', '2014-05-03 08:32:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('272', 'User has logged off.', '1', '2014-05-03 08:35:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('273', 'User has logged on.', '1', '2014-05-03 08:49:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('274', 'User has logged off.', '1', '2014-05-03 08:50:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('275', 'User has logged on.', '1', '2014-05-03 09:13:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('276', 'User has logged on.', '1', '2014-05-03 09:18:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('277', 'User has logged off.', '1', '2014-05-03 09:19:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('278', 'User has logged on.', '1', '2014-05-03 09:39:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('279', 'User has logged on.', '1', '2014-05-03 09:42:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('280', 'User has logged on.', '1', '2014-05-03 09:44:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('281', 'User has logged on.', '1', '2014-05-03 09:47:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('282', 'User has logged off.', '1', '2014-05-03 09:48:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('283', 'User has logged on.', '1', '2014-05-03 10:00:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('284', 'User has logged off.', '1', '2014-05-03 10:02:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('285', 'User has logged on.', '1', '2014-05-03 14:14:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('286', 'User has logged on.', '1', '2014-05-03 14:43:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('287', 'User has recorded a new user account. Recorded new User\'s ID is 13', '1', '2014-05-03 14:54:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('288', 'User has updated user account. Updated User\'s ID is 6', '1', '2014-05-03 14:56:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('289', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 7', '1', '2014-05-03 14:57:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('290', 'User has updated Lesson. Updated Lesson\'s ID is 7', '1', '2014-05-03 14:57:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('291', 'User has deleted Lesson. Deleted Lesson\'s ID is 7', '1', '2014-05-03 14:57:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('292', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 7', '1', '2014-05-03 14:58:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('293', 'User has updated Lesson Subject. Updated Lesson Subject\'s ID is ', '1', '2014-05-03 14:59:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('294', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is ', '1', '2014-05-03 14:59:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('295', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 7', '1', '2014-05-03 15:00:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('296', 'User has logged off.', '1', '2014-05-03 15:01:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('297', 'User has logged on.', '1', '2014-05-03 15:22:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('298', 'User has updated Lesson Sub-Topic. Updated Lesson Sub-Topic\'s ID is ', '1', '2014-05-03 15:25:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('299', 'User has logged off.', '1', '2014-05-03 15:31:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('300', 'User has logged on.', '1', '2014-05-03 16:36:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('301', 'User has logged off.', '1', '2014-05-03 16:37:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('302', 'User has logged on.', '1', '2014-05-03 16:59:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('303', 'User has deleted Lesson Sub-Topic. Deleted Lesson Sub-Topic\'s ID is 7', '1', '2014-05-03 17:00:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('304', 'User has logged off.', '1', '2014-05-03 17:01:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('305', 'User has logged on.', '1', '2014-05-03 21:32:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('306', 'User has logged on.', '1', '2014-05-03 21:40:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('307', 'User has logged off.', '1', '2014-05-03 21:40:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('308', 'User has logged on.', '1', '2014-05-03 21:48:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('309', 'User has logged off.', '1', '2014-05-03 21:50:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('310', 'User has logged on.', '1', '2014-05-03 23:29:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('311', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is 1', '1', '2014-05-03 23:32:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('312', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is 5', '1', '2014-05-03 23:34:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('313', 'User has logged off.', '1', '2014-05-03 23:34:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('314', 'User has logged on.', '1', '2014-05-04 00:11:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('315', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 8', '1', '2014-05-04 00:11:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('316', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 8', '1', '2014-05-04 00:11:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('317', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 9', '1', '2014-05-04 00:12:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('318', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 8', '1', '2014-05-04 00:12:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('319', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 9', '1', '2014-05-04 00:12:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('320', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 10', '1', '2014-05-04 00:12:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('321', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 11', '1', '2014-05-04 00:13:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('322', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 10', '1', '2014-05-04 00:13:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('323', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 12', '1', '2014-05-04 00:13:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('324', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 13', '1', '2014-05-04 00:13:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('325', 'User has deleted Lesson Sub-Topic. Deleted Lesson Sub-Topic\'s ID is 13', '1', '2014-05-04 00:19:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('326', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is 9', '1', '2014-05-04 00:20:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('327', 'User has deleted Lesson. Deleted Lesson\'s ID is 8', '1', '2014-05-04 00:20:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('328', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 9', '1', '2014-05-04 00:22:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('329', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 11', '1', '2014-05-04 00:22:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('330', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 12', '1', '2014-05-04 00:23:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('331', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 13', '1', '2014-05-04 00:23:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('332', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 14', '1', '2014-05-04 00:23:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('333', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 15', '1', '2014-05-04 00:23:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('334', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 16', '1', '2014-05-04 00:24:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('335', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 17', '1', '2014-05-04 00:24:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('336', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 18', '1', '2014-05-04 00:24:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('337', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 10', '1', '2014-05-04 00:31:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('338', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 19', '1', '2014-05-04 00:32:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('339', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 20', '1', '2014-05-04 00:32:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('340', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 21', '1', '2014-05-04 00:32:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('341', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 22', '1', '2014-05-04 00:32:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('342', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 23', '1', '2014-05-04 00:33:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('343', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 24', '1', '2014-05-04 00:33:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('344', 'User has logged off.', '1', '2014-05-04 00:35:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('345', 'User has logged on.', '1', '2014-05-04 09:00:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('346', 'User has logged on.', '1', '2014-05-04 09:04:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('347', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is 13', '1', '2014-05-04 09:05:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('348', 'User has deleted Lesson. Deleted Lesson\'s ID is 9', '1', '2014-05-04 09:06:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('349', 'User has logged off.', '1', '2014-05-04 09:09:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('350', 'User has logged on.', '1', '2014-05-04 09:16:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('351', 'User has deleted Lesson Subject. Deleted Lesson Subject\'s ID is 6', '1', '2014-05-04 09:17:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('352', 'User has deleted Lesson. Deleted Lesson\'s ID is 10', '1', '2014-05-04 09:17:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('353', 'User has logged off.', '1', '2014-05-04 09:17:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('354', 'User has logged on.', '1', '2014-05-04 16:13:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('355', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 6', '1', '2014-05-04 16:25:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('356', 'User has logged on.', '1', '2014-05-04 16:31:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('357', 'User has logged on.', '1', '2014-05-04 16:44:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('358', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 5', '1', '2014-05-04 16:48:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('359', 'User has logged off.', '1', '2014-05-04 16:53:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('360', 'User has logged on.', '1', '2014-05-04 16:55:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('361', 'User has logged off.', '1', '2014-05-04 17:01:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('362', 'User has logged on.', '1', '2014-05-04 17:35:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('363', 'User has logged on.', '1', '2014-05-04 17:35:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('364', 'User has logged off.', '1', '2014-05-04 17:36:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('365', 'User has logged on.', '1', '2014-05-04 19:51:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('366', 'User has logged off.', '1', '2014-05-04 19:52:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('367', 'User has logged on.', '1', '2014-05-04 20:14:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('368', 'User has logged off.', '1', '2014-05-04 20:26:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('369', 'User has logged on.', '1', '2014-05-04 22:25:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('370', 'User has recorded a new question. Recorded new Question\'s ID is 1', '1', '2014-05-04 22:26:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('371', 'User has recorded a new question. Recorded new Question\'s ID is 2', '1', '2014-05-04 22:29:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('372', 'User has recorded a new question. Recorded new Question\'s ID is 3', '1', '2014-05-04 22:31:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('373', 'User has recorded a new question. Recorded new Question\'s ID is 4', '1', '2014-05-04 22:33:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('374', 'User has recorded a new question. Recorded new Question\'s ID is 5', '1', '2014-05-04 22:33:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('375', 'User has recorded a new question. Recorded new Question\'s ID is 6', '1', '2014-05-04 22:34:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('376', 'User has recorded a new question. Recorded new Question\'s ID is 7', '1', '2014-05-04 22:34:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('377', 'User has recorded a new question. Recorded new Question\'s ID is 8', '1', '2014-05-04 22:35:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('378', 'User has recorded a new question. Recorded new Question\'s ID is 9', '1', '2014-05-04 22:35:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('379', 'User has recorded a new question. Recorded new Question\'s ID is 10', '1', '2014-05-04 22:36:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('380', 'User has logged on.', '1', '2014-05-04 22:37:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('381', 'User has recorded a new question. Recorded new Question\'s ID is 11', '1', '2014-05-04 22:38:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('382', 'User has recorded a new question. Recorded new Question\'s ID is 12', '1', '2014-05-04 22:41:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('383', 'User has recorded a new question. Recorded new Question\'s ID is 13', '1', '2014-05-04 22:42:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('384', 'User has logged off.', '1', '2014-05-04 22:43:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('385', 'User has logged on.', '1', '2014-05-05 08:13:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('386', 'User has logged off.', '1', '2014-05-05 08:22:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('387', 'User has logged on.', '1', '2014-05-05 08:37:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('388', 'User has recorded a new question. Recorded new Question\'s ID is 14', '1', '2014-05-05 08:37:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('389', 'User has logged on.', '1', '2014-05-05 09:05:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('390', 'User has recorded a new question. Recorded new Question\'s ID is 15', '1', '2014-05-05 09:29:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('391', 'User has recorded a new question. Recorded new Question\'s ID is 16', '1', '2014-05-05 09:31:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('392', 'User has recorded a new question. Recorded new Question\'s ID is 17', '1', '2014-05-05 09:32:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('393', 'User has recorded a new question. Recorded new Question\'s ID is 18', '1', '2014-05-05 09:39:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('394', 'User has logged off.', '1', '2014-05-05 09:44:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('395', 'User has logged on.', '1', '2014-05-05 09:51:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('396', 'User has recorded a new question. Recorded new Question\'s ID is 19', '1', '2014-05-05 09:52:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('397', 'User has recorded a new question. Recorded new Question\'s ID is 20', '1', '2014-05-05 09:57:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('398', 'User has recorded a new question. Recorded new Question\'s ID is 21', '1', '2014-05-05 10:07:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('399', 'User has recorded a new question. Recorded new Question\'s ID is 22', '1', '2014-05-05 10:10:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('400', 'User has recorded a new question. Recorded new Question\'s ID is 23', '1', '2014-05-05 10:10:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('401', 'User has recorded a new question. Recorded new Question\'s ID is 24', '1', '2014-05-05 10:13:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('402', 'User has logged off.', '1', '2014-05-05 10:14:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('403', 'User has logged on.', '1', '2014-05-05 15:39:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('404', 'User has logged on.', '1', '2014-05-05 15:50:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('405', 'User has logged off.', '1', '2014-05-05 15:53:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('406', 'User has logged on.', '1', '2014-05-05 16:28:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('407', 'User has logged off.', '1', '2014-05-05 16:31:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('408', 'User has logged on.', '1', '2014-05-05 22:06:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('409', 'User has logged off.', '1', '2014-05-05 22:19:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('410', 'User has logged on.', '1', '2014-05-05 22:47:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('411', 'User has logged on.', '1', '2014-05-05 23:15:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('412', 'User has logged on.', '1', '2014-05-05 23:24:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('413', 'User has logged on.', '1', '2014-05-05 23:55:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('414', 'User has logged on.', '1', '2014-05-06 07:23:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('415', 'User has logged off.', '1', '2014-05-06 07:41:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('416', 'User has logged on.', '1', '2014-05-06 07:53:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('417', 'User has recorded a new question. Recorded new Question\'s ID is 25', '1', '2014-05-06 07:55:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('418', 'User has logged on.', '1', '2014-05-06 08:03:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('419', 'User has logged on.', '1', '2014-05-06 08:10:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('420', 'User has logged on.', '1', '2014-05-06 08:11:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('421', 'User has logged on.', '1', '2014-05-06 08:14:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('422', 'User has logged on.', '1', '2014-05-06 08:19:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('423', 'User has logged on.', '1', '2014-05-06 08:40:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('424', 'User has logged off.', '1', '2014-05-06 08:46:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('425', 'User has logged on.', '1', '2014-05-06 10:50:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('426', 'User has logged off.', '1', '2014-05-06 11:14:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('427', 'User has logged on.', '1', '2014-05-06 12:59:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('428', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 13:01:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('429', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 13:14:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('430', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 13:16:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('431', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 13:19:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('432', 'User has logged off.', '1', '2014-05-06 13:20:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('433', 'User has logged on.', '1', '2014-05-06 15:23:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('434', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 15:25:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('435', 'User has logged on.', '1', '2014-05-06 15:27:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('436', 'User has updated question. Updated Question\'s ID is 25', '1', '2014-05-06 15:28:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('437', 'User has updated question. Updated Question\'s ID is 24', '1', '2014-05-06 15:29:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('438', 'User has updated question. Updated Question\'s ID is 24', '1', '2014-05-06 15:30:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('439', 'User has updated question. Updated Question\'s ID is 24', '1', '2014-05-06 15:30:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('440', 'User has updated question. Updated Question\'s ID is 24', '1', '2014-05-06 15:31:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('441', 'User has updated question. Updated Question\'s ID is 2', '1', '2014-05-06 15:32:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('442', 'User has updated question. Updated Question\'s ID is 2', '1', '2014-05-06 15:33:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('443', 'User has logged off.', '1', '2014-05-06 15:50:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('444', 'User has logged on.', '1', '2014-05-06 15:57:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('445', 'User has updated question. Updated Question\'s ID is 2', '1', '2014-05-06 15:58:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('446', 'User has updated question. Updated Question\'s ID is 2', '1', '2014-05-06 16:04:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('447', 'User has recorded a new question. Recorded new Question\'s ID is 26', '1', '2014-05-06 16:05:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('448', 'User has updated question. Updated Question\'s ID is 26', '1', '2014-05-06 16:06:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('449', 'User has updated question. Updated Question\'s ID is 26', '1', '2014-05-06 16:09:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('450', 'User has updated question. Updated Question\'s ID is 26', '1', '2014-05-06 16:11:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('451', 'User has logged off.', '1', '2014-05-06 16:12:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('452', 'User has logged on.', '1', '2014-05-06 16:50:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('453', 'User has logged off.', '1', '2014-05-06 16:51:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('454', 'User has logged on.', '1', '2014-05-06 22:48:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('455', 'User has deleted Question. Deleted Lesson Sub-Topic\'s ID is 25', '1', '2014-05-06 23:01:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('456', 'User has logged off.', '1', '2014-05-06 23:01:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('457', 'User has logged on.', '1', '2014-05-07 16:05:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('458', 'User has logged off.', '1', '2014-05-07 16:18:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('459', 'User has logged on.', '1', '2014-05-08 09:21:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('460', 'User has recorded a new exam. Recorded new Exam\'s ID is 1', '1', '2014-05-08 09:26:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('461', 'User has logged off.', '1', '2014-05-08 09:36:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('462', 'User has logged on.', '1', '2014-05-08 09:46:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('463', 'User has logged on.', '1', '2014-05-08 09:54:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('464', 'User has recorded a new exam. Recorded new Exam\'s ID is 2', '1', '2014-05-08 09:54:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('465', 'User has logged off.', '1', '2014-05-08 09:56:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('466', 'User has logged on.', '1', '2014-05-08 16:16:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('467', 'User has recorded a new exam. Recorded new Exam\'s ID is 3', '1', '2014-05-08 16:17:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('468', 'User has logged on.', '1', '2014-05-08 16:23:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('469', 'User has logged on.', '1', '2014-05-08 16:25:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('470', 'User has recorded a new exam. Recorded new Exam\'s ID is 4', '1', '2014-05-08 16:26:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('471', 'User has logged on.', '1', '2014-05-08 16:45:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('472', 'User has recorded a new exam. Recorded new Exam\'s ID is 5', '1', '2014-05-08 16:45:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('473', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 1', '1', '2014-05-08 16:48:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('474', 'User has logged on.', '1', '2014-05-08 16:55:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('475', 'User has recorded a new exam. Recorded new Exam\'s ID is 6', '1', '2014-05-08 16:55:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('476', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 2', '1', '2014-05-08 16:55:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('477', 'User has logged on.', '1', '2014-05-08 17:08:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('478', 'User has recorded a new exam. Recorded new Exam\'s ID is 7', '1', '2014-05-08 17:08:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('479', 'User has logged on.', '1', '2014-05-08 17:13:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('480', 'User has recorded a new exam. Recorded new Exam\'s ID is 8', '1', '2014-05-08 17:13:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('481', 'User has logged on.', '1', '2014-05-08 17:20:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('482', 'User has recorded a new exam. Recorded new Exam\'s ID is 9', '1', '2014-05-08 17:20:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('483', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 3', '1', '2014-05-08 17:20:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('484', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 4', '1', '2014-05-08 17:21:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('485', 'User has logged off.', '1', '2014-05-08 17:21:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('486', 'User has logged on.', '1', '2014-05-08 23:05:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('487', 'User has recorded a new exam. Recorded new Exam\'s ID is 10', '1', '2014-05-08 23:07:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('488', 'User has logged on.', '1', '2014-05-08 23:09:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('489', 'User has recorded a new exam. Recorded new Exam\'s ID is 11', '1', '2014-05-08 23:10:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('490', 'User has logged on.', '1', '2014-05-08 23:12:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('491', 'User has recorded a new exam. Recorded new Exam\'s ID is 12', '1', '2014-05-08 23:12:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('492', 'User has recorded a new exam. Recorded new Exam\'s ID is 13', '1', '2014-05-08 23:23:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('493', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 5', '1', '2014-05-08 23:24:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('494', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 5', '1', '2014-05-08 23:25:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('495', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 5', '1', '2014-05-08 23:28:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('496', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 6', '1', '2014-05-08 23:29:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('497', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 7', '1', '2014-05-08 23:29:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('498', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 8', '1', '2014-05-08 23:30:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('499', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 7', '1', '2014-05-08 23:30:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('500', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 6', '1', '2014-05-08 23:34:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('501', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 5', '1', '2014-05-08 23:37:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('502', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 8', '1', '2014-05-08 23:59:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('503', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 9', '1', '2014-05-09 00:00:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('504', 'User has logged on.', '1', '2014-05-09 00:05:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('505', 'User has recorded a new exam. Recorded new Exam\'s ID is 14', '1', '2014-05-09 00:05:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('506', 'User has logged on.', '1', '2014-05-09 00:08:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('507', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 7', '1', '2014-05-09 00:09:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('508', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 10', '1', '2014-05-09 00:17:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('509', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 11', '1', '2014-05-09 00:17:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('510', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 12', '1', '2014-05-09 00:17:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('511', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 9', '1', '2014-05-09 00:18:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('512', 'User has logged off.', '1', '2014-05-09 00:20:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('513', 'User has logged on.', '1', '2014-05-09 11:20:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('514', 'User has logged on.', '1', '2014-05-09 11:25:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('515', 'User has logged off.', '1', '2014-05-09 11:27:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('516', 'User has logged on.', '1', '2014-05-09 11:48:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('517', 'User has logged on.', '1', '2014-05-09 11:50:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('518', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 11:50:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('519', 'User has logged off.', '1', '2014-05-09 11:51:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('520', 'User has logged on.', '1', '2014-05-09 11:53:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('521', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 11:53:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('522', 'User has logged off.', '1', '2014-05-09 11:54:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('523', 'User has logged on.', '1', '2014-05-09 11:58:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('524', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 11:58:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('525', 'User has logged on.', '1', '2014-05-09 12:49:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('526', 'User has logged on.', '1', '2014-05-09 12:49:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('527', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 12:49:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('528', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 12:51:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('529', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 13', '1', '2014-05-09 12:51:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('530', 'User has logged off.', '1', '2014-05-09 12:52:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('531', 'User has logged on.', '1', '2014-05-09 12:54:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('532', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 12:54:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('533', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 13:05:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('534', 'User has recorded a new lesson subject. Recorded new Lesson subject\'s ID is 6', '1', '2014-05-09 13:06:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('535', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 13:06:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('536', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 8', '1', '2014-05-09 13:07:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('537', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-09 13:07:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('538', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 14', '1', '2014-05-09 13:08:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('539', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 15', '1', '2014-05-09 13:08:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('540', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 16', '1', '2014-05-09 13:08:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('541', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 17', '1', '2014-05-09 13:08:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('542', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 14', '1', '2014-05-09 13:12:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('543', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 18', '1', '2014-05-09 13:13:08', '127.0.0.1');
INSERT INTO `t_log` VALUES ('544', 'User has logged off.', '1', '2014-05-09 13:16:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('545', 'User has logged on.', '1', '2014-05-09 15:02:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('546', 'User has logged on.', '1', '2014-05-09 15:26:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('547', 'User has logged off.', '1', '2014-05-09 15:35:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('548', 'User has logged on.', '1', '2014-05-09 15:43:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('549', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 19', '1', '2014-05-09 15:44:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('550', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 20', '1', '2014-05-09 15:45:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('551', 'User has recorded a new exam. Recorded new Exam\'s ID is 15', '1', '2014-05-09 15:49:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('552', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 21', '1', '2014-05-09 15:49:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('553', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 22', '1', '2014-05-09 15:49:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('554', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 23', '1', '2014-05-09 15:49:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('555', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 24', '1', '2014-05-09 15:50:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('556', 'User has logged off.', '1', '2014-05-09 15:50:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('557', 'User has logged on.', '1', '2014-05-09 17:08:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('558', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 25', '1', '2014-05-09 17:12:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('559', 'User has logged off.', '1', '2014-05-09 17:12:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('560', 'User has logged on.', '1', '2014-05-10 17:38:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('561', 'User has logged off.', '1', '2014-05-10 17:41:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('562', 'User has logged on.', '1', '2014-05-12 13:19:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('563', 'User has logged off.', '1', '2014-05-12 13:20:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('564', 'User has changed his\\her password and logged on to application.', '7', '2014-05-12 13:20:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('565', 'User has logged on.', '7', '2014-05-12 13:58:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('566', 'User has logged off.', '7', '2014-05-12 14:00:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('567', 'User has logged on.', '7', '2014-05-12 15:09:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('568', 'User has logged off.', '7', '2014-05-12 15:10:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('569', 'User has logged on.', '1', '2014-05-12 15:10:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('570', 'User has recorded a new question. Recorded new Question\'s ID is 104', '1', '2014-05-12 15:15:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('571', 'User has recorded a new question. Recorded new Question\'s ID is 105', '1', '2014-05-12 15:16:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('572', 'User has recorded a new question. Recorded new Question\'s ID is 106', '1', '2014-05-12 15:16:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('573', 'User has recorded a new question. Recorded new Question\'s ID is 107', '1', '2014-05-12 15:16:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('574', 'User has recorded a new question. Recorded new Question\'s ID is 108', '1', '2014-05-12 15:17:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('575', 'User has recorded a new question. Recorded new Question\'s ID is 109', '1', '2014-05-12 15:17:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('576', 'User has recorded a new question. Recorded new Question\'s ID is 110', '1', '2014-05-12 15:17:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('577', 'User has recorded a new question. Recorded new Question\'s ID is 111', '1', '2014-05-12 15:18:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('578', 'User has recorded a new question. Recorded new Question\'s ID is 112', '1', '2014-05-12 15:18:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('579', 'User has updated an exam. Updated Exam\'s ID is 1', '1', '2014-05-12 15:19:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('580', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 25', '1', '2014-05-12 15:32:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('581', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 26', '1', '2014-05-12 15:33:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('582', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 22', '1', '2014-05-12 15:34:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('583', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 24', '1', '2014-05-12 15:35:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('584', 'User has logged on.', '1', '2014-05-12 16:29:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('585', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 27', '1', '2014-05-12 16:35:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('586', 'User has logged on.', '1', '2014-05-12 16:44:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('587', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 28', '1', '2014-05-12 16:46:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('588', 'User has logged off.', '1', '2014-05-12 16:47:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('589', 'User has logged on.', '1', '2014-05-13 10:31:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('590', 'User has logged off.', '1', '2014-05-13 10:43:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('591', 'User has logged on.', '1', '2014-05-13 10:56:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('592', 'User has updated question. Updated Question\'s ID is 14', '1', '2014-05-13 10:58:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('593', 'User has updated question. Updated Question\'s ID is 15', '1', '2014-05-13 10:58:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('594', 'User has updated question. Updated Question\'s ID is 1', '1', '2014-05-13 10:59:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('595', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 21', '1', '2014-05-13 11:03:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('596', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 27', '1', '2014-05-13 11:03:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('597', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 22', '1', '2014-05-13 11:03:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('598', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 28', '1', '2014-05-13 11:03:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('599', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 24', '1', '2014-05-13 11:03:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('600', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 26', '1', '2014-05-13 11:03:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('601', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 29', '1', '2014-05-13 11:03:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('602', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 30', '1', '2014-05-13 11:04:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('603', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 31', '1', '2014-05-13 11:04:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('604', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 32', '1', '2014-05-13 11:04:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('605', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 33', '1', '2014-05-13 11:04:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('606', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 34', '1', '2014-05-13 11:05:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('607', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 35', '1', '2014-05-13 11:05:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('608', 'User has recorded a new exam. Recorded new Exam\'s ID is 16', '1', '2014-05-13 11:08:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('609', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 36', '1', '2014-05-13 11:08:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('610', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 37', '1', '2014-05-13 11:08:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('611', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 38', '1', '2014-05-13 11:09:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('612', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 39', '1', '2014-05-13 11:09:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('613', 'User has logged on.', '1', '2014-05-13 13:11:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('614', 'User has logged off.', '1', '2014-05-13 13:12:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('615', 'User has logged on.', '1', '2014-05-13 14:28:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('616', 'User has updated question. Updated Question\'s ID is 15', '1', '2014-05-13 15:02:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('617', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-13 15:21:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('618', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-13 15:25:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('619', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-13 15:28:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('620', 'User has logged off.', '1', '2014-05-13 15:30:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('621', 'User has logged on.', '1', '2014-05-13 16:23:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('622', 'User has logged off.', '1', '2014-05-13 16:26:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('623', 'User has logged on.', '1', '2014-05-13 16:56:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('624', 'User has logged on.', '1', '2014-05-13 17:02:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('625', 'User has logged off.', '1', '2014-05-13 17:03:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('626', 'User has logged on.', '1', '2014-05-13 21:03:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('627', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 39', '1', '2014-05-13 21:04:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('628', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-13 21:04:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('629', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 31', '1', '2014-05-13 21:05:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('630', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-13 21:05:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('631', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 40', '1', '2014-05-13 21:08:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('632', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-13 21:08:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('633', 'User has logged off.', '1', '2014-05-13 21:08:56', '127.0.0.1');
INSERT INTO `t_log` VALUES ('634', 'User has logged on.', '1', '2014-05-13 21:18:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('635', 'User has logged off.', '1', '2014-05-13 21:18:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('636', 'User has logged on.', '1', '2014-05-13 21:52:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('637', 'User has updated question. Updated Question\'s ID is 15', '1', '2014-05-13 21:56:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('638', 'User has logged off.', '1', '2014-05-13 21:57:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('639', 'User has logged on.', '1', '2014-05-13 22:16:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('640', 'User has logged off.', '1', '2014-05-13 22:16:53', '127.0.0.1');
INSERT INTO `t_log` VALUES ('641', 'User has logged on.', '1', '2014-05-14 09:10:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('642', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 41', '1', '2014-05-14 09:15:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('643', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-14 09:15:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('644', 'User has logged off.', '1', '2014-05-14 09:15:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('645', 'User has logged on.', '1', '2014-05-14 15:39:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('646', 'User has changed Exam Question. Changed Exam\'s ID is 16 and old exam question\'s ID is 111 and new exam question\'s ID is 15', '1', '2014-05-14 15:45:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('647', 'User has changed Exam Question. Changed Exam\'s ID is 16 and old exam question\'s ID is 15 and new exam question\'s ID is 111', '1', '2014-05-14 15:45:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('648', 'User has recorded new exam question count. Recorded new Exam Question Count\'s ID is 42', '1', '2014-05-14 15:47:34', '127.0.0.1');
INSERT INTO `t_log` VALUES ('649', 'User has generated exam questions. Question generated Exam\'s ID is 16', '1', '2014-05-14 15:47:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('650', 'User has changed Exam Question. Changed Exam\'s ID is 16 and old exam question\'s ID is 110 and new exam question\'s ID is 6', '1', '2014-05-14 15:47:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('651', 'User has changed Exam Question. Changed Exam\'s ID is 16 and old exam question\'s ID is 3 and new exam question\'s ID is 5', '1', '2014-05-14 15:48:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('652', 'User has logged off.', '1', '2014-05-14 15:49:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('653', 'User has logged on.', '1', '2014-05-14 16:04:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('654', 'User has logged off.', '1', '2014-05-14 16:14:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('655', 'User has logged on.', '1', '2014-05-14 16:40:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('656', 'User has deleted Exam. Deleted Exam\'s ID is 11', '1', '2014-05-14 16:40:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('657', 'User has logged off.', '1', '2014-05-14 16:53:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('658', 'User has logged on.', '1', '2014-05-14 17:15:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('659', 'User has deleted Exam. Deleted Exam\'s ID is 16', '1', '2014-05-14 17:16:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('660', 'User has logged off.', '1', '2014-05-14 17:17:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('661', 'User has logged on.', '1', '2014-05-14 19:02:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('662', 'User has logged off.', '1', '2014-05-14 19:03:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('663', 'User has logged on.', '1', '2014-05-14 19:03:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('664', 'User has logged off.', '1', '2014-05-14 19:04:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('665', 'User has logged on.', '1', '2014-05-14 19:14:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('666', 'User has logged off.', '1', '2014-05-14 19:17:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('667', 'User has logged on.', '1', '2014-05-14 21:01:39', '127.0.0.1');
INSERT INTO `t_log` VALUES ('668', 'User has deleted Exam. Deleted Exam\'s ID is 14', '1', '2014-05-14 21:02:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('669', 'User has deleted Exam. Deleted Exam\'s ID is 12', '1', '2014-05-14 21:03:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('670', 'User has logged on.', '1', '2014-05-14 21:06:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('671', 'User has recorded a new lesson sub-topic. Recorded new Lesson sub-topic\'s ID is 9', '1', '2014-05-14 21:10:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('672', 'User has deleted Lesson Sub-Topic. Deleted Lesson Sub-Topic\'s ID is 9', '1', '2014-05-14 21:10:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('673', 'User has logged on.', '1', '2014-05-14 21:14:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('674', 'User has deleted Question. Deleted question\'s ID is 4', '1', '2014-05-14 21:14:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('675', 'User has recorded a new exam. Recorded new Exam\'s ID is 17', '1', '2014-05-14 21:15:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('676', 'User has deleted Exam. Deleted Exam\'s ID is 17', '1', '2014-05-14 21:16:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('677', 'User has logged off.', '1', '2014-05-14 21:16:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('678', 'User has logged on.', '1', '2014-05-14 21:37:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('679', 'User has logged on.', '1', '2014-05-14 21:59:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('680', 'User has recorded a new user account. Recorded new User\'s ID is 14', '1', '2014-05-14 22:10:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('681', 'User has recorded a new user account. Recorded new User\'s ID is 15', '1', '2014-05-14 22:17:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('682', 'User has updated user account. Updated User\'s ID is 14', '1', '2014-05-14 22:23:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('683', 'User has updated user password. Updated User\'s ID is 14', '1', '2014-05-14 22:23:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('684', 'User has logged on.', '1', '2014-05-15 09:18:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('685', 'User has recorded a new user account. Recorded new User\'s ID is 16', '1', '2014-05-15 09:21:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('686', 'User has logged off.', '1', '2014-05-15 09:21:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('687', 'User has changed his\\her password and logged on to application.', '16', '2014-05-15 09:25:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('688', 'User has logged off.', '16', '2014-05-15 09:25:42', '127.0.0.1');
INSERT INTO `t_log` VALUES ('689', 'User has logged on.', '1', '2014-05-15 09:26:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('690', 'User has recorded a new lesson. Recorded new Lesson\'s ID is 7', '1', '2014-05-15 09:28:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('691', 'User has updated Lesson. Updated Lesson\'s ID is 7', '1', '2014-05-15 09:33:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('692', 'User has logged off.', '1', '2014-05-15 09:43:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('693', 'User has logged on.', '1', '2014-05-15 13:09:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('694', 'User has logged off.', '1', '2014-05-15 13:25:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('695', 'User has logged on.', '1', '2014-05-15 17:35:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('696', 'User has logged off.', '1', '2014-05-15 17:36:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('697', 'User has logged on.', '1', '2014-05-15 21:15:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('698', 'User has logged on.', '1', '2014-05-15 21:50:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('699', 'User has changed his\\her password and logged on to application.', '1', '2014-05-15 22:06:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('700', 'User has logged off.', '1', '2014-05-15 22:06:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('701', 'User has logged on.', '1', '2014-05-15 22:07:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('702', 'User has logged on.', '1', '2014-05-15 22:30:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('703', 'User has logged on.', '1', '2014-05-15 22:54:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('704', 'User has recorded a new exam. Recorded new Exam\'s ID is 16', '1', '2014-05-15 22:54:52', '127.0.0.1');
INSERT INTO `t_log` VALUES ('705', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 30', '1', '2014-05-15 22:59:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('706', 'User has deleted exam question count. Deleted Question Count of Exam\'s ID is 35', '1', '2014-05-15 23:02:03', '127.0.0.1');
INSERT INTO `t_log` VALUES ('707', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-15 23:02:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('708', 'User has changed Exam Question. Changed Exam\'s ID is 15 and old exam question\'s ID is 111 and new exam question\'s ID is 15', '1', '2014-05-15 23:07:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('709', 'User has logged off.', '1', '2014-05-15 23:20:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('710', 'User has changed his\\her password and logged on to application.', '1', '2014-05-16 00:03:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('711', 'User has logged off.', '1', '2014-05-16 00:03:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('712', 'User has changed his\\her password and logged on to application.', '1', '2014-05-16 00:09:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('713', 'User has logged off.', '1', '2014-05-16 00:12:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('714', 'User has changed his\\her password and logged on to application.', '1', '2014-05-16 00:14:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('715', 'User has logged off.', '1', '2014-05-16 00:14:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('716', 'User has changed his\\her password and logged on to application.', '1', '2014-05-16 00:18:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('717', 'User has recorded a new user account. Recorded new User\'s ID is 17', '1', '2014-05-16 00:37:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('718', 'User has recorded a new user account. Recorded new User\'s ID is 18', '1', '2014-05-16 00:44:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('719', 'User has recorded a new user account. Recorded new User\'s ID is 19', '1', '2014-05-16 00:50:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('720', 'User has logged on.', '1', '2014-05-16 01:03:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('721', 'User has recorded a new user account. Recorded new User\'s ID is 20', '1', '2014-05-16 01:05:15', '127.0.0.1');
INSERT INTO `t_log` VALUES ('722', 'User has updated user password. Updated User\'s ID is 6', '1', '2014-05-16 01:09:54', '127.0.0.1');
INSERT INTO `t_log` VALUES ('723', 'User has logged off.', '1', '2014-05-16 01:10:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('724', 'User has logged on.', '1', '2014-05-16 01:10:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('725', 'User has logged off.', '1', '2014-05-16 01:10:30', '127.0.0.1');
INSERT INTO `t_log` VALUES ('726', 'User has changed his\\her password and logged on to application.', '1', '2014-05-16 01:11:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('727', 'User has logged off.', '1', '2014-05-16 01:12:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('728', 'User has logged on.', '1', '2014-05-16 01:20:13', '127.0.0.1');
INSERT INTO `t_log` VALUES ('729', 'User has logged off.', '1', '2014-05-16 01:21:27', '127.0.0.1');
INSERT INTO `t_log` VALUES ('730', 'User has logged on.', '1', '2014-05-16 13:16:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('731', 'User has logged off.', '1', '2014-05-16 13:28:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('732', 'User has logged on.', '1', '2014-05-16 13:28:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('733', 'User has logged on.', '1', '2014-05-16 13:31:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('734', 'User has logged on.', '1', '2014-05-16 13:33:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('735', 'User has logged on.', '1', '2014-05-16 13:37:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('736', 'User has logged off.', '1', '2014-05-16 13:42:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('737', 'User has logged on.', '1', '2014-05-16 14:52:59', '127.0.0.1');
INSERT INTO `t_log` VALUES ('738', 'User has logged off.', '1', '2014-05-16 14:56:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('739', 'User has logged on.', '1', '2014-05-16 16:28:12', '127.0.0.1');
INSERT INTO `t_log` VALUES ('740', 'User has logged on.', '1', '2014-05-16 16:33:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('741', 'User has logged on.', '1', '2014-05-16 16:36:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('742', 'User has logged on.', '1', '2014-05-16 16:39:17', '127.0.0.1');
INSERT INTO `t_log` VALUES ('743', 'User has logged on.', '1', '2014-05-16 16:40:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('744', 'User has logged on.', '1', '2014-05-16 16:42:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('745', 'User has logged on.', '1', '2014-05-16 16:44:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('746', 'User has logged on.', '1', '2014-05-16 16:47:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('747', 'User has logged on.', '1', '2014-05-16 16:58:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('748', 'User has logged on.', '1', '2014-05-16 17:00:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('749', 'User has logged on.', '1', '2014-05-16 17:01:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('750', 'User has logged on.', '1', '2014-05-16 19:17:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('751', 'User has logged on.', '1', '2014-05-16 19:18:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('752', 'User has logged on.', '1', '2014-05-16 19:21:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('753', 'User has logged on.', '1', '2014-05-16 19:23:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('754', 'User has logged on.', '1', '2014-05-16 19:25:10', '127.0.0.1');
INSERT INTO `t_log` VALUES ('755', 'User has logged on.', '1', '2014-05-16 19:28:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('756', 'User has logged off.', '1', '2014-05-16 19:28:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('757', 'User has logged on.', '1', '2014-05-16 19:29:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('758', 'User has logged off.', '1', '2014-05-16 19:29:57', '127.0.0.1');
INSERT INTO `t_log` VALUES ('759', 'User has logged on.', '1', '2014-05-16 19:53:40', '127.0.0.1');
INSERT INTO `t_log` VALUES ('760', 'User has logged on.', '1', '2014-05-16 19:57:23', '127.0.0.1');
INSERT INTO `t_log` VALUES ('761', 'User has logged off.', '1', '2014-05-16 19:59:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('762', 'User has logged on.', '1', '2014-05-16 19:59:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('763', 'User has logged off.', '1', '2014-05-16 20:00:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('764', 'User has logged on.', '1', '2014-05-16 20:48:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('765', 'User has logged on.', '1', '2014-05-16 20:51:01', '127.0.0.1');
INSERT INTO `t_log` VALUES ('766', 'User has logged on.', '1', '2014-05-16 20:52:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('767', 'User has logged on.', '1', '2014-05-16 20:53:36', '127.0.0.1');
INSERT INTO `t_log` VALUES ('768', 'User has logged on.', '1', '2014-05-16 20:59:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('769', 'User has deleted Question. Deleted question\'s ID is 15', '1', '2014-05-16 21:00:09', '127.0.0.1');
INSERT INTO `t_log` VALUES ('770', 'User has deleted Question. Deleted question\'s ID is 7', '1', '2014-05-16 21:02:21', '127.0.0.1');
INSERT INTO `t_log` VALUES ('771', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-16 21:04:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('772', 'User has deleted Question. Deleted question\'s ID is 5', '1', '2014-05-16 21:04:50', '127.0.0.1');
INSERT INTO `t_log` VALUES ('773', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-16 21:06:37', '127.0.0.1');
INSERT INTO `t_log` VALUES ('774', 'User has deleted Question. Deleted question\'s ID is 14', '1', '2014-05-16 21:07:33', '127.0.0.1');
INSERT INTO `t_log` VALUES ('775', 'User has logged on.', '1', '2014-05-16 21:09:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('776', 'User has logged off.', '1', '2014-05-16 21:12:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('777', 'User has logged on.', '1', '2014-05-16 21:59:47', '127.0.0.1');
INSERT INTO `t_log` VALUES ('778', 'User has logged on.', '1', '2014-05-16 22:01:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('779', 'User has logged off.', '1', '2014-05-16 22:10:28', '127.0.0.1');
INSERT INTO `t_log` VALUES ('780', 'User has logged on.', '1', '2014-05-16 22:47:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('781', 'User has logged off.', '1', '2014-05-16 22:52:25', '127.0.0.1');
INSERT INTO `t_log` VALUES ('782', 'User has logged on.', '1', '2014-05-16 22:52:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('783', 'User has logged off.', '1', '2014-05-16 22:54:46', '127.0.0.1');
INSERT INTO `t_log` VALUES ('784', 'User has logged on.', '1', '2014-05-16 22:55:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('785', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 41', '1', '2014-05-16 23:01:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('786', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 42', '1', '2014-05-16 23:02:05', '127.0.0.1');
INSERT INTO `t_log` VALUES ('787', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 43', '1', '2014-05-16 23:02:16', '127.0.0.1');
INSERT INTO `t_log` VALUES ('788', 'User has updated new exam question count. Updated new Exam Question Count\'s ID is 44', '1', '2014-05-16 23:02:24', '127.0.0.1');
INSERT INTO `t_log` VALUES ('789', 'User has generated exam questions. Question generated Exam\'s ID is 15', '1', '2014-05-16 23:02:29', '127.0.0.1');
INSERT INTO `t_log` VALUES ('790', 'User has logged off.', '1', '2014-05-16 23:03:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('791', 'User has logged on.', '1', '2014-05-16 23:23:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('792', 'User has logged off.', '1', '2014-05-16 23:25:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('793', 'User has logged on.', '1', '2014-05-16 23:42:18', '127.0.0.1');
INSERT INTO `t_log` VALUES ('794', 'User has logged off.', '1', '2014-05-16 23:45:20', '127.0.0.1');
INSERT INTO `t_log` VALUES ('795', 'User has logged on.', '1', '2014-05-17 14:56:41', '127.0.0.1');
INSERT INTO `t_log` VALUES ('796', 'User has logged on.', '1', '2014-05-17 15:03:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('797', 'User has logged off.', '1', '2014-05-17 15:23:19', '127.0.0.1');
INSERT INTO `t_log` VALUES ('798', 'User has logged on.', '1', '2014-05-18 11:11:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('799', 'User has logged on.', '1', '2014-05-18 11:22:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('800', 'User has logged off.', '1', '2014-05-18 11:25:06', '127.0.0.1');
INSERT INTO `t_log` VALUES ('801', 'User has logged on.', '1', '2014-05-18 11:34:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('802', 'User has published exam. Published Exam\'s ID is 15', '1', '2014-05-18 11:37:26', '127.0.0.1');
INSERT INTO `t_log` VALUES ('803', 'User has logged on.', '1', '2014-05-18 14:00:35', '127.0.0.1');
INSERT INTO `t_log` VALUES ('804', 'User has published exam. Published Exam\'s ID is 15', '1', '2014-05-18 14:01:02', '127.0.0.1');
INSERT INTO `t_log` VALUES ('805', 'User has logged on.', '1', '2014-05-18 14:30:04', '127.0.0.1');
INSERT INTO `t_log` VALUES ('806', 'User has published exam. Published Exam\'s ID is 15', '1', '2014-05-18 14:30:14', '127.0.0.1');
INSERT INTO `t_log` VALUES ('807', 'User has published exam. Published Exam\'s ID is 15', '1', '2014-05-18 14:42:45', '127.0.0.1');
INSERT INTO `t_log` VALUES ('808', 'User has logged on.', '1', '2014-05-18 14:43:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('809', 'User has published exam. Published Exam\'s ID is 15', '1', '2014-05-18 14:43:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('810', 'User has logged off.', '1', '2014-05-18 14:52:00', '127.0.0.1');
INSERT INTO `t_log` VALUES ('811', 'User has logged on.', '1', '2014-05-18 19:18:58', '127.0.0.1');
INSERT INTO `t_log` VALUES ('812', 'User has logged on.', '1', '2014-05-18 19:25:38', '127.0.0.1');
INSERT INTO `t_log` VALUES ('813', 'User has logged on.', '1', '2014-05-18 21:04:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('814', 'User has published exam. Published Exam\'s ID is 16', '1', '2014-05-18 21:09:43', '127.0.0.1');
INSERT INTO `t_log` VALUES ('815', 'User has logged on.', '1', '2014-05-18 22:30:48', '127.0.0.1');
INSERT INTO `t_log` VALUES ('816', 'User has logged on.', '1', '2014-05-18 22:46:44', '127.0.0.1');
INSERT INTO `t_log` VALUES ('817', 'User has logged on.', '1', '2014-05-18 23:21:11', '127.0.0.1');
INSERT INTO `t_log` VALUES ('818', 'User has logged on.', '1', '2014-05-18 23:27:32', '127.0.0.1');
INSERT INTO `t_log` VALUES ('819', 'User has logged on.', '1', '2014-05-18 23:31:51', '127.0.0.1');
INSERT INTO `t_log` VALUES ('820', 'User has logged off.', '1', '2014-05-18 23:33:55', '127.0.0.1');
INSERT INTO `t_log` VALUES ('821', 'User has logged on.', '1', '2014-05-19 00:07:07', '127.0.0.1');
INSERT INTO `t_log` VALUES ('822', 'User has logged on.', '1', '2014-05-19 00:15:22', '127.0.0.1');
INSERT INTO `t_log` VALUES ('823', 'User has canceled publishing exam. Publishing Canceled Exam\'s ID is 15', '1', '2014-05-19 00:15:31', '127.0.0.1');
INSERT INTO `t_log` VALUES ('824', 'User has canceled publishing exam. Publishing Canceled Exam\'s ID is 16', '1', '2014-05-19 00:15:49', '127.0.0.1');
INSERT INTO `t_log` VALUES ('825', 'User has logged off.', '1', '2014-05-19 00:16:13', '127.0.0.1');

-- ----------------------------
-- Table structure for `t_question`
-- ----------------------------
DROP TABLE IF EXISTS `t_question`;
CREATE TABLE `t_question` (
  `QUESTION_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_CONTENT` varchar(500) NOT NULL,
  `QUESTION_PHOTO` varchar(100) DEFAULT NULL,
  `QUESTION_TYPE_ID` int(11) NOT NULL,
  `LESSON_SUB_TOPIC_ID` int(11) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  `USER_ID` int(11) NOT NULL,
  `QUESTION_DIFFICULTY_ID` int(11) NOT NULL,
  PRIMARY KEY (`QUESTION_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_question
-- ----------------------------
INSERT INTO `t_question` VALUES ('1', 'q.', 'images\\que_2kargo3.jpg', '1', '6', '2014-05-04 22:26:24', '1', '3');
INSERT INTO `t_question` VALUES ('2', 'My new question.\r\nTake it easy.', 'images\\que_2kargo3.jpg', '2', '6', '2014-05-04 22:29:32', '1', '1');
INSERT INTO `t_question` VALUES ('3', 'My third question.\r\nTake it easy.', 'images\\12Koala.jpg', '2', '6', '2014-05-04 22:31:16', '1', '2');
INSERT INTO `t_question` VALUES ('6', 'My third question.\r\nTake it easy.', 'images\\que_2kargo3.jpg', '2', '6', '2014-05-04 22:34:33', '1', '2');
INSERT INTO `t_question` VALUES ('8', 'My third question.\r\nTake it easy.', 'images\\12Koala.jpg', '2', '6', '2014-05-04 22:35:00', '1', '3');
INSERT INTO `t_question` VALUES ('9', 'My third question.\r\nTake it easy.', 'images\\11main-125x125-u4jxeyq.jpg', '2', '6', '2014-05-04 22:35:09', '1', '3');
INSERT INTO `t_question` VALUES ('10', 'My third question.\r\nTake it easy.', 'images\\que_2kargo3.jpg', '2', '6', '2014-05-04 22:36:45', '1', '3');
INSERT INTO `t_question` VALUES ('11', 'ewrhgff', 'images\\11main-125x125-u4jxeyq.jpg', '2', '6', '2013-05-04 22:38:46', '1', '3');
INSERT INTO `t_question` VALUES ('12', 'qww\r\nddfdv\r\ndfdsgsdgs', 'images\\12Koala.jpg', '2', '6', '2013-07-04 22:41:17', '1', '3');
INSERT INTO `t_question` VALUES ('101', 'q', 'images\\que_2kargo3.jpg', '2', '7', '2014-05-12 08:48:31', '1', '3');
INSERT INTO `t_question` VALUES ('102', 'a', 'images\\12Koala.jpg', '1', '2', '2014-05-12 08:49:07', '1', '2');
INSERT INTO `t_question` VALUES ('103', 's', 'images\\12Koala.jpg', '1', '1', '2014-05-12 08:49:30', '1', '3');
INSERT INTO `t_question` VALUES ('104', 'fsdfsdfs fsdfsdf fsdfs ff s', 'images\\que_2kargo3.jpg', '2', '6', '2014-05-12 15:15:48', '1', '1');
INSERT INTO `t_question` VALUES ('105', '3233ds sdfdsf', 'images\\11main-125x125-u4jxeyq.jpg', '1', '6', '2014-05-12 15:16:17', '1', '2');
INSERT INTO `t_question` VALUES ('106', 'gfdg gfg ghfdghdfh ', 'images\\12Koala.jpg', '2', '6', '2014-05-12 15:16:32', '1', '3');
INSERT INTO `t_question` VALUES ('107', 'www', 'images\\que_2kargo3.jpg', '1', '6', '2014-05-12 15:16:53', '1', '3');
INSERT INTO `t_question` VALUES ('108', 'qqq', 'images\\12Koala.jpg', '1', '6', '2014-05-12 15:17:23', '1', '3');
INSERT INTO `t_question` VALUES ('109', 'q1q2q3', 'images\\11main-125x125-u4jxeyq.jpg', '2', '6', '2014-05-12 15:17:42', '1', '3');
INSERT INTO `t_question` VALUES ('110', 'qawsed', 'images\\que_2kargo3.jpg', '2', '6', '2014-05-12 15:17:56', '1', '2');
INSERT INTO `t_question` VALUES ('111', 'qwe', 'images\\12Koala.jpg', '1', '6', '2014-05-12 15:18:24', '1', '1');
INSERT INTO `t_question` VALUES ('112', 'w2q1a3d5', 'images\\11main-125x125-u4jxeyq.jpg', '2', '6', '2014-05-12 15:18:40', '1', '3');

-- ----------------------------
-- Table structure for `t_question_difficulty`
-- ----------------------------
DROP TABLE IF EXISTS `t_question_difficulty`;
CREATE TABLE `t_question_difficulty` (
  `QUESTION_DIFFICULTY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_DIFFICULTY_DEGREE` int(11) NOT NULL,
  PRIMARY KEY (`QUESTION_DIFFICULTY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_question_difficulty
-- ----------------------------
INSERT INTO `t_question_difficulty` VALUES ('1', '1');
INSERT INTO `t_question_difficulty` VALUES ('2', '2');
INSERT INTO `t_question_difficulty` VALUES ('3', '3');
INSERT INTO `t_question_difficulty` VALUES ('4', '4');

-- ----------------------------
-- Table structure for `t_question_option`
-- ----------------------------
DROP TABLE IF EXISTS `t_question_option`;
CREATE TABLE `t_question_option` (
  `QUESTION_OPTION_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_OPTION_CONTENT` varchar(500) NOT NULL,
  `QUESTION_OPTION_PHOTO` varchar(100) DEFAULT NULL,
  `QUESTION_ID` int(11) NOT NULL,
  `QUESTION_OPTION_TRUE` char(1) NOT NULL,
  PRIMARY KEY (`QUESTION_OPTION_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_question_option
-- ----------------------------
INSERT INTO `t_question_option` VALUES ('1', 'First test option.', '', '19', 'N');
INSERT INTO `t_question_option` VALUES ('2', 'Second test option.', '', '19', 'N');
INSERT INTO `t_question_option` VALUES ('3', 'Third test option.', '', '19', 'Y');
INSERT INTO `t_question_option` VALUES ('4', 'Fourth test option.', '', '19', 'N');
INSERT INTO `t_question_option` VALUES ('5', 'Fifth test option.', '', '19', 'N');
INSERT INTO `t_question_option` VALUES ('6', '22', '', '23', 'N');
INSERT INTO `t_question_option` VALUES ('7', '11', '', '23', 'N');
INSERT INTO `t_question_option` VALUES ('8', '55', '', '23', 'N');
INSERT INTO `t_question_option` VALUES ('9', '77', '', '23', 'Y');
INSERT INTO `t_question_option` VALUES ('10', '99', '', '23', 'N');
INSERT INTO `t_question_option` VALUES ('11', 'البالب الالالا فقفقف ', 'images\\que_opt_113230-2-1-499-1-1-hills-reflected-on-lake-tablo.jpg', '24', 'N');
INSERT INTO `t_question_option` VALUES ('12', 'غ سبسب بیسبسببب ثسبز ', '', '24', 'N');
INSERT INTO `t_question_option` VALUES ('13', 'غغر  بسبسیب بسبسب ', '', '24', 'N');
INSERT INTO `t_question_option` VALUES ('14', 'ففف لبلب لبیلیب یبلیلی', '', '24', 'N');
INSERT INTO `t_question_option` VALUES ('15', 'تات لابا بالبالبا بابلابا ', '', '24', 'Y');
INSERT INTO `t_question_option` VALUES ('16', 'fdsf', '', '105', 'N');
INSERT INTO `t_question_option` VALUES ('17', '3sad', '', '105', 'Y');
INSERT INTO `t_question_option` VALUES ('18', 'gdfg', '', '105', 'N');
INSERT INTO `t_question_option` VALUES ('19', 'gdgdf', '', '105', 'N');
INSERT INTO `t_question_option` VALUES ('20', 'gfhg', '', '105', 'N');
INSERT INTO `t_question_option` VALUES ('21', 'eee', '', '107', 'N');
INSERT INTO `t_question_option` VALUES ('22', 'ddd', '', '107', 'N');
INSERT INTO `t_question_option` VALUES ('23', 'fff', '', '107', 'N');
INSERT INTO `t_question_option` VALUES ('24', 'ggg', '', '107', 'N');
INSERT INTO `t_question_option` VALUES ('25', 'vvv', '', '107', 'Y');
INSERT INTO `t_question_option` VALUES ('26', 'aa', '', '108', 'N');
INSERT INTO `t_question_option` VALUES ('27', 'bbbb', '', '108', 'N');
INSERT INTO `t_question_option` VALUES ('28', 'ccccccc', '', '108', 'N');
INSERT INTO `t_question_option` VALUES ('29', 'dddddddddd', '', '108', 'N');
INSERT INTO `t_question_option` VALUES ('30', 'eeeeeeeeeeeee', '', '108', 'Y');
INSERT INTO `t_question_option` VALUES ('31', 'asd', '', '111', 'N');
INSERT INTO `t_question_option` VALUES ('32', 'zxc', '', '111', 'N');
INSERT INTO `t_question_option` VALUES ('33', 'ert', '', '111', 'Y');
INSERT INTO `t_question_option` VALUES ('34', 'fgh', '', '111', 'N');
INSERT INTO `t_question_option` VALUES ('35', 'bnm', '', '111', 'N');
INSERT INTO `t_question_option` VALUES ('46', 'www', '', '1', 'Y');
INSERT INTO `t_question_option` VALUES ('47', 'qqq', '', '1', 'N');
INSERT INTO `t_question_option` VALUES ('48', 'ccc', '', '1', 'N');
INSERT INTO `t_question_option` VALUES ('49', 'ddd', '', '1', 'N');
INSERT INTO `t_question_option` VALUES ('50', 'sss', '', '1', 'N');

-- ----------------------------
-- Table structure for `t_question_option_template`
-- ----------------------------
DROP TABLE IF EXISTS `t_question_option_template`;
CREATE TABLE `t_question_option_template` (
  `QUESTION_OPTION_TEMPLATE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_OPTION_ID` int(11) NOT NULL,
  `EXAM_QUESTION_TEMPLATE_ID` int(11) NOT NULL,
  `QUESTION_OPTION_ORDER` int(11) NOT NULL,
  PRIMARY KEY (`QUESTION_OPTION_TEMPLATE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=601 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_question_option_template
-- ----------------------------

-- ----------------------------
-- Table structure for `t_question_type`
-- ----------------------------
DROP TABLE IF EXISTS `t_question_type`;
CREATE TABLE `t_question_type` (
  `QUESTION_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_TYPE_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`QUESTION_TYPE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_question_type
-- ----------------------------
INSERT INTO `t_question_type` VALUES ('1', 'test');
INSERT INTO `t_question_type` VALUES ('2', 'clasic');

-- ----------------------------
-- Table structure for `t_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_rank`;
CREATE TABLE `t_rank` (
  `RANK_ID` int(11) NOT NULL AUTO_INCREMENT,
  `RANK_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`RANK_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_rank
-- ----------------------------
INSERT INTO `t_rank` VALUES ('1', 'Major General');
INSERT INTO `t_rank` VALUES ('2', 'Brigadier General');
INSERT INTO `t_rank` VALUES ('3', 'Colonel');
INSERT INTO `t_rank` VALUES ('4', 'Lieutenant Colonel');
INSERT INTO `t_rank` VALUES ('5', 'Major');
INSERT INTO `t_rank` VALUES ('6', 'Captain');
INSERT INTO `t_rank` VALUES ('7', 'Lieutenant');
INSERT INTO `t_rank` VALUES ('8', 'First Lieutenant');
INSERT INTO `t_rank` VALUES ('9', 'First Sergeant');
INSERT INTO `t_rank` VALUES ('10', 'Sergeant');

-- ----------------------------
-- Table structure for `t_user`
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `USER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `USER_NAME` varchar(20) NOT NULL,
  `REAL_NAME` varchar(50) NOT NULL,
  `RANK_ID` int(11) NOT NULL,
  `ACTIVE` char(1) NOT NULL,
  `USER_PASSWORD` varchar(100) NOT NULL,
  `PASSWORD_CHANGED` char(1) NOT NULL,
  `CREATED_DATE` datetime NOT NULL,
  `HOST_IP` varchar(15) NOT NULL,
  `DEPARTMENT_ID` int(11) NOT NULL,
  `USER_TASK` varchar(50) NOT NULL,
  PRIMARY KEY (`USER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'CS_QB_Admin', 'بیس', '7', 'Y', 'MQ==', 'Y', '2014-04-23 16:41:36', '127.0.0.1', '1', 'فققب ییشگ بیس');
INSERT INTO `t_user` VALUES ('6', 'user5', 'Abdullah Sami', '5', 'N', '2LbYtNi4MTIzNDU=', 'N', '2014-04-30 08:52:18', '127.0.0.1', '1', 'Teacher2');
INSERT INTO `t_user` VALUES ('7', 'user7', 'Abdullah', '5', 'Y', 'cWF6d3N4MT8=', 'Y', '2014-04-30 10:07:15', '127.0.0.1', '2', 'Teacher');
INSERT INTO `t_user` VALUES ('8', 'user11', 'Feyzullah', '8', 'Y', 'cWF6MzIxPz8=', 'N', '2014-04-28 21:41:01', '127.0.0.1', '1', 'Teacher');
INSERT INTO `t_user` VALUES ('9', 'user10', 'Ahmet', '10', 'N', 'WlhDMDk4dT8=', 'N', '2014-04-30 08:54:48', '127.0.0.1', '1', 'Teacher');
INSERT INTO `t_user` VALUES ('10', 'user6', 'Ahmet', '5', 'Y', 'cWF6d3N4MTIzPw==', 'N', '2014-04-30 09:44:01', '127.0.0.1', '1', 'Web Design Teacher');
INSERT INTO `t_user` VALUES ('11', 'user12', 'Halit', '4', 'Y', 'cWF6MTIzPz8=', 'N', '2014-04-28 22:14:15', '127.0.0.1', '1', 'Teacher');
INSERT INTO `t_user` VALUES ('12', 'Musti', 'Mustafa', '5', 'Y', 'MTIzNDVxd2VyPw==', 'N', '2014-04-30 16:48:39', '127.0.0.1', '1', 'Computer  Language\'s Teacher');
INSERT INTO `t_user` VALUES ('13', 'user4', 'Halid', '6', 'N', 'MTIzcXdlPz8=', 'N', '2014-05-03 14:54:56', '127.0.0.1', '1', 'Teacher');
INSERT INTO `t_user` VALUES ('14', 'سیبیس ', 'لاتیبیس س', '6', 'Y', '2LbYtNi4MTIz', 'N', '2014-05-14 22:10:35', '127.0.0.1', '1', 'یبل صثق');
INSERT INTO `t_user` VALUES ('15', 'ضصث', 'ضشظ', '8', 'Y', '2LbYtdirMTIz', 'N', '2014-05-14 22:17:21', '127.0.0.1', '1', 'شسیظطز بلا');
INSERT INTO `t_user` VALUES ('16', 'ششش', 'ضصث', '9', 'Y', '2LXYs9i3MTIz', 'Y', '2014-05-15 09:21:02', '127.0.0.1', '1', 'سیب قفغ ادق');
INSERT INTO `t_user` VALUES ('17', 'زیس', 'زسش', '7', 'Y', 'MTIz2LQ=', 'N', '2014-05-16 00:37:23', '127.0.0.1', '1', 'طزی الف صث');
INSERT INTO `t_user` VALUES ('18', 'ثیز', 'ضشظ', '8', 'Y', '2LbYtNi4', 'N', '2014-05-16 00:44:37', '127.0.0.1', '1', 'صسط');
INSERT INTO `t_user` VALUES ('19', 'ضشث', 'ض', '1', 'Y', '2LbYtNi4MTIz', 'N', '2014-05-16 00:50:06', '127.0.0.1', '1', 'یسبیس');
INSERT INTO `t_user` VALUES ('20', 'شسیب', 'ضشظ', '7', 'Y', '2LbYtNi4MTIzNDU=', 'N', '2014-05-16 01:05:15', '127.0.0.1', '1', 'سییس');

-- ----------------------------
-- Table structure for `t_user_authority`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_authority`;
CREATE TABLE `t_user_authority` (
  `user_authority_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `authority_id` int(11) NOT NULL,
  PRIMARY KEY (`user_authority_id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_authority
-- ----------------------------
INSERT INTO `t_user_authority` VALUES ('1', '1', '1');
INSERT INTO `t_user_authority` VALUES ('2', '1', '2');
INSERT INTO `t_user_authority` VALUES ('3', '1', '3');
INSERT INTO `t_user_authority` VALUES ('16', '8', '2');
INSERT INTO `t_user_authority` VALUES ('19', '11', '3');
INSERT INTO `t_user_authority` VALUES ('20', '11', '4');
INSERT INTO `t_user_authority` VALUES ('21', '1', '4');
INSERT INTO `t_user_authority` VALUES ('35', '9', '3');
INSERT INTO `t_user_authority` VALUES ('36', '10', '4');
INSERT INTO `t_user_authority` VALUES ('38', '7', '3');
INSERT INTO `t_user_authority` VALUES ('39', '7', '2');
INSERT INTO `t_user_authority` VALUES ('42', '12', '3');
INSERT INTO `t_user_authority` VALUES ('43', '12', '4');
INSERT INTO `t_user_authority` VALUES ('44', '12', '2');
INSERT INTO `t_user_authority` VALUES ('45', '13', '3');
INSERT INTO `t_user_authority` VALUES ('46', '6', '3');
INSERT INTO `t_user_authority` VALUES ('49', '15', '3');
INSERT INTO `t_user_authority` VALUES ('50', '15', '4');
INSERT INTO `t_user_authority` VALUES ('51', '14', '3');
INSERT INTO `t_user_authority` VALUES ('52', '14', '4');
INSERT INTO `t_user_authority` VALUES ('53', '16', '3');
INSERT INTO `t_user_authority` VALUES ('54', '16', '2');
INSERT INTO `t_user_authority` VALUES ('55', '17', '2');
INSERT INTO `t_user_authority` VALUES ('56', '17', '3');
INSERT INTO `t_user_authority` VALUES ('57', '18', '2');
INSERT INTO `t_user_authority` VALUES ('58', '18', '3');
INSERT INTO `t_user_authority` VALUES ('59', '19', '3');
INSERT INTO `t_user_authority` VALUES ('60', '20', '2');
INSERT INTO `t_user_authority` VALUES ('61', '20', '3');
INSERT INTO `t_user_authority` VALUES ('62', '20', '4');

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM`(IN `pi_exam_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
   delete from t_exam
   where exam_id=pi_exam_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_QUESTION`(IN `pi_exam_question_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
  delete from t_exam_question
where exam_question_id=pi_exam_question_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_QUESTION_ALL`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_QUESTION_ALL`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_QUESTION_ALL`(IN `pi_exam_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
  delete from t_exam_question
where exam_id=pi_exam_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_QUESTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_QUESTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_QUESTION_TEMPLATE`(IN `pi_exam_question_template_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from  t_exam_question_template
where exam_question_template_id=pi_exam_question_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT`(IN `pi_exam_sub_top_que_count_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
   delete from t_exam_sub_top_que_count
   where exam_sub_top_que_count_id=pi_exam_sub_top_que_count_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT_ALL`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT_ALL`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_SUB_TOP_QUE_COUNT_ALL`(IN `pi_exam_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
   delete from t_exam_sub_top_que_count
   where exam_id=pi_exam_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_EXAM_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_EXAM_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_EXAM_TEMPLATE`(IN `pi_exam_template_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_exam_template
where exam_template_id=pi_exam_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON`(IN `pi_lesson_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson
where lesson_id=pi_lesson_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON_SUB_TOPIC`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON_SUB_TOPIC`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON_SUB_TOPIC`(IN `pi_lesson_sub_topic_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson_sub_topic
where lesson_sub_topic_id=pi_lesson_sub_topic_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON`(IN `pi_lesson_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson_sub_topic
where lesson_subject_id in (select lesson_subject_id from t_lesson_subject where lesson_id=pi_lesson_id);
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON_SUBJECT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON_SUBJECT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON_SUB_TOPIC_FOR_LESSON_SUBJECT`(IN `pi_lesson_subject_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson_sub_topic
where lesson_subject_id=pi_lesson_subject_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON_SUBJECT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON_SUBJECT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON_SUBJECT`(IN `pi_lesson_subject_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson_subject
where lesson_subject_id=pi_lesson_subject_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_LESSON_SUBJECT_FOR_LESSON`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_LESSON_SUBJECT_FOR_LESSON`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_LESSON_SUBJECT_FOR_LESSON`(IN `pi_lesson_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_lesson_subject
where lesson_id=pi_lesson_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_QUESTION`(IN `pi_question_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_question
where question_id=pi_question_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_QUESTION_ALL_OPTIONS`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_QUESTION_ALL_OPTIONS`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_QUESTION_ALL_OPTIONS`(IN `pi_question_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_question_option
where question_id=pi_question_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_QUESTION_OPTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_QUESTION_OPTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_QUESTION_OPTION`(IN `pi_question_option_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete from t_question_option
where question_option_id=pi_question_option_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_QUESTION_OPTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_QUESTION_OPTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_QUESTION_OPTION_TEMPLATE`(IN `pi_question_option_template_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
delete  from t_question_option_template
where question_option_template_id=pi_question_option_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_DEL_T_USER_AUTHORITY`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_DEL_T_USER_AUTHORITY`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_DEL_T_USER_AUTHORITY`(IN `pi_user_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
   delete from t_user_authority
   where user_id = pi_user_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_EXAM`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_EXAM`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_EXAM`(IN `pi_exam_name` text,IN `pi_lesson_id` int,IN `pi_created_date` datetime,IN `pi_user_id` int,IN `pi_asked_year` text,IN `pi_exam_question_finished` text,OUT `po_exam_id` int)
BEGIN
	#Routine body goes here...
insert into t_exam
(
exam_name,
lesson_id,
created_date,
user_id,
asked_year,
exam_question_finished
)
values
(
pi_exam_name,
pi_lesson_id,
pi_created_date,
pi_user_id,
pi_asked_year,
pi_exam_question_finished
);
select last_insert_id() into po_exam_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_EXAM_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_EXAM_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_EXAM_QUESTION`(OUT `po_exam_question_id` int,IN `pi_exam_id` int,IN `pi_question_id` int,IN `pi_question_success_rate` text)
BEGIN
	#Routine body goes here...
insert into t_exam_question
(
exam_id,
question_id,
question_success_rate
)
values
(
pi_exam_id,
pi_question_id,
pi_question_success_rate
);
select last_insert_id() into po_exam_question_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_EXAM_QUESTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_EXAM_QUESTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_EXAM_QUESTION_TEMPLATE`(OUT `po_exam_question_template_id` int,IN `pi_exam_template_id` int,IN `pi_exam_question_id` int,IN `pi_exam_question_order` int)
BEGIN
	#Routine body goes here...
insert into t_exam_question_template
(
exam_template_id,
exam_question_id,
exam_question_order
)
values
(
pi_exam_template_id,
pi_exam_question_id,
pi_exam_question_order
);
select last_insert_id() into po_exam_question_template_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_EXAM_SUB_TOP_QUE_COUNT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_EXAM_SUB_TOP_QUE_COUNT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_EXAM_SUB_TOP_QUE_COUNT`(IN `pi_exam_id` int,IN `pi_lesson_sub_topic_id` int,IN `pi_question_difficulty_id` int,IN `pi_question_count` int,IN `pi_question_type_id` int,OUT `po_exam_sub_top_que_count_id` int)
BEGIN
	#Routine body goes here...
insert into t_exam_sub_top_que_count
(
exam_id,
lesson_sub_topic_id,
question_difficulty_id,
question_count,
question_type_id
)
values
(
pi_exam_id,
pi_lesson_sub_topic_id,
pi_question_difficulty_id,
pi_question_count,
pi_question_type_id
);
select last_insert_id() into po_exam_sub_top_que_count_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_EXAM_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_EXAM_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_EXAM_TEMPLATE`(OUT `po_exam_template_id` int,IN `pi_exam_group_id` int,IN `pi_exam_id` int,IN `pi_created_date` datetime)
BEGIN
	#Routine body goes here...
insert into t_exam_template
(
exam_group_id,
exam_id,
created_date
)
values
(
pi_exam_group_id,
pi_exam_id,
pi_created_date
);
select last_insert_id() into po_exam_template_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_LESSON`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_LESSON`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_LESSON`(OUT `po_lesson_id` int,IN `pi_lesson_name` text,IN `pi_lesson_code` text,IN `pi_department_id` int,IN `pi_lesson_class` text,IN `pi_lesson_term` text,IN `pi_created_date` datetime)
BEGIN
	#Routine body goes here...
insert into t_lesson
(
lesson_name,
lesson_code,
department_id,
lesson_class,
lesson_term,
created_date
)
values
(
pi_lesson_name,
pi_lesson_code,
pi_department_id,
pi_lesson_class,
pi_lesson_term,
pi_created_date
);
select last_insert_id() into po_lesson_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_LESSON_SUB_TOPIC`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_LESSON_SUB_TOPIC`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_LESSON_SUB_TOPIC`(OUT `po_lesson_sub_topic_id` int,IN `pi_lesson_sub_topic_name` text,IN `pi_lesson_sub_topic_code` text,IN `pi_lesson_subject_id` int,IN `pi_created_date` datetime)
BEGIN
	#Routine body goes here...
insert into t_lesson_sub_topic
(
lesson_sub_topic_name,
lesson_sub_topic_code,
lesson_subject_id,
created_date
)
values
(
pi_lesson_sub_topic_name,
pi_lesson_sub_topic_code,
pi_lesson_subject_id,
pi_created_date
);
select last_insert_id() into po_lesson_sub_topic_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_LESSON_SUBJECT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_LESSON_SUBJECT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_LESSON_SUBJECT`(OUT `po_lesson_subject_id` int,IN `pi_lesson_subject_name` text,IN `pi_lesson_subject_code` text,IN `pi_lesson_id` int,IN `pi_created_date` datetime)
BEGIN
	#Routine body goes here...
insert into t_lesson_subject
(
lesson_subject_name,
lesson_subject_code,
lesson_id,
created_date
)
values
(
pi_lesson_subject_name,
pi_lesson_subject_code,
pi_lesson_id,
pi_created_date
);
select last_insert_id() into po_lesson_subject_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_LOG`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_LOG`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_LOG`(IN `pi_log_content` text,IN `pi_user_id` int,IN `pi_log_date` datetime,IN `pi_host_ip` text,OUT `po_log_id` int)
BEGIN
	#Routine body goes here...
insert into T_LOG
(
log_content,
user_id,
log_date,
host_ip
)
values
(
pi_log_content,
pi_user_id,
pi_log_date,
pi_host_ip
);
select LAST_INSERT_ID() into po_log_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_QUESTION`(OUT `po_question_id` int,IN `pi_question_content` text,IN `pi_question_photo` text,IN `pi_question_type_id` int,IN `pi_lesson_sub_topic_id` int,IN `pi_created_date` datetime,IN `pi_user_id` int,IN `pi_question_difficulty_id` int)
BEGIN
	#Routine body goes here...
insert into t_question
(
question_content,
question_photo,
question_type_id,
lesson_sub_topic_id,
created_date,
user_id,
question_difficulty_id
)
values
(
pi_question_content,
pi_question_photo,
pi_question_type_id,
pi_lesson_sub_topic_id,
pi_created_date,
pi_user_id,
pi_question_difficulty_id
);
select last_insert_id() into po_question_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_QUESTION_OPTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_QUESTION_OPTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_QUESTION_OPTION`(OUT `po_question_option_id` int,IN `pi_question_option_content` text,IN `pi_question_option_photo` text,IN `pi_question_id` int,IN `pi_question_option_true` text)
BEGIN
	#Routine body goes here...
insert into t_question_option
(
question_option_content,
question_option_photo,
question_id,
question_option_true
)
values
(
pi_question_option_content,
pi_question_option_photo,
pi_question_id,
pi_question_option_true
);
select last_insert_id() into po_question_option_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_QUESTION_OPTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_QUESTION_OPTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_QUESTION_OPTION_TEMPLATE`(OUT `po_question_option_template_id` int,IN `pi_question_option_id` int,IN `pi_exam_question_template_id` int,IN `pi_question_option_order` int)
BEGIN
	#Routine body goes here...
insert into t_question_option_template
(
question_option_id,
exam_question_template_id,
question_option_order
)
values
(
pi_question_option_id, 
pi_exam_question_template_id,
pi_question_option_order
);
select last_insert_id() into po_question_option_template_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_USER`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_USER`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_USER`(OUT `po_user_id` int,IN `pi_user_name` text,IN `pi_real_name` text,IN `pi_rank_id` int,IN `pi_active` text,IN `pi_user_password` text,IN `pi_password_changed` text,IN `pi_created_date` datetime,IN `pi_host_ip` text,IN `pi_department_id` int,IN `pi_user_task` text)
BEGIN
	#Routine body goes here...
insert into T_USER
(
user_name,
real_name,
rank_id,
active,
user_password,
password_changed,
created_date,
host_ip,
department_id,
user_task
)
values
(
pi_user_name,
pi_real_name,
pi_rank_id,
pi_active,
pi_user_password,
pi_password_changed,
pi_created_date,
pi_host_ip,
pi_department_id,
pi_user_task
);
select LAST_INSERT_ID() into po_user_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_INS_T_USER_AUTHORITY`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_INS_T_USER_AUTHORITY`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_INS_T_USER_AUTHORITY`(IN `pi_user_id` int,IN `pi_authority_id` int,OUT `po_user_authority_id` int)
BEGIN
	#Routine body goes here...
insert into t_user_authority
(
user_id,
authority_id
)
values
(
pi_user_id,
pi_authority_id
);     
select last_insert_id() into po_user_authority_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_EXAM_COUNT_ABOUT_LES_SUB_TOPIC`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_EXAM_COUNT_ABOUT_LES_SUB_TOPIC`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_EXAM_COUNT_ABOUT_LES_SUB_TOPIC`(IN `pi_lesson_sub_topic_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
select count( distinct teq.exam_id) into po_rows from t_exam_question teq,t_question tq where tq.question_id=teq.question_id and tq.lesson_sub_topic_id=pi_lesson_sub_topic_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_LES_COUNT_ABOUT_LES_SUB_IN_EXAMS`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_LES_COUNT_ABOUT_LES_SUB_IN_EXAMS`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_LES_COUNT_ABOUT_LES_SUB_IN_EXAMS`(IN `pi_lesson_subject_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
select count(te.lesson_id) into po_rows from t_exam te,t_lesson_subject tls where tls.lesson_subject_id=pi_lesson_subject_id and tls.lesson_id=te.lesson_id and te.exam_question_finished="Y";
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_LES_COUNT_IN_EXAMS`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_LES_COUNT_IN_EXAMS`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_LES_COUNT_IN_EXAMS`(IN `pi_lesson_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
select count(lesson_id) into po_rows from t_exam where lesson_id=pi_lesson_id and exam_question_finished="Y";
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_QUE_COUNT_IN_EXAMS`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_QUE_COUNT_IN_EXAMS`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_QUE_COUNT_IN_EXAMS`(IN `pi_question_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
select count(question_id) into po_rows from T_exam_question where question_id=pi_question_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_QUE_OPT_ORDER_IN_EXAM`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_QUE_OPT_ORDER_IN_EXAM`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_QUE_OPT_ORDER_IN_EXAM`(IN `pi_exam_id` int,IN `pi_exam_group_id` int,IN `pi_exam_question_id` int,IN `pi_question_option_order` int,OUT `po_rows` int)
BEGIN
select count(question_option_template_id) into po_rows from t_question_option_template tqot,t_exam_question_template teqt,t_exam_template tet where tet.exam_id=pi_exam_id and tet.exam_group_id=pi_exam_group_id and teqt.exam_question_id=pi_exam_question_id and teqt.exam_template_id=tet.exam_template_id and  tqot.exam_question_template_id=teqt.exam_question_template_id and tqot.question_option_order=pi_question_option_order;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_QUE_ORDER_IN_EXAM_GROUP`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_QUE_ORDER_IN_EXAM_GROUP`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_QUE_ORDER_IN_EXAM_GROUP`(IN `pi_exam_id` int,IN `pi_exam_group_id` int,IN `pi_exam_question_order` int,OUT `po_rows` int)
BEGIN
select count(exam_question_template_id) into po_rows from t_exam_question_template teqt,t_exam_template tet where tet.exam_id=pi_exam_id and tet.exam_template_id=teqt.exam_template_id and tet.exam_group_id=pi_exam_group_id and teqt.exam_question_order=pi_exam_question_order;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_T_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_T_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_T_QUESTION`(IN `pi_question_type_id` int,IN `pi_lesson_sub_topic_id` int,IN `pi_question_difficulty_id` int,OUT `po_que_count` int)
BEGIN
	#Routine body goes here...
select count(question_id) into po_que_count  from T_question where question_type_id=pi_question_type_id and lesson_sub_topic_id=pi_lesson_sub_topic_id and question_difficulty_id=pi_question_difficulty_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_SEL_T_QUESTION_FOR_EXAM`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_SEL_T_QUESTION_FOR_EXAM`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_SEL_T_QUESTION_FOR_EXAM`(IN `pi_lesson_sub_topic_id` int,IN `pi_question_difficulty_id` int,IN `pi_question_type_id` int,OUT `po_question_id` int)
BEGIN
select question_id into po_question_id from t_question where question_id not in (select question_id from t_exam_question) and lesson_sub_topic_id=pi_lesson_sub_topic_id and question_difficulty_id=pi_question_difficulty_id and question_type_id=pi_question_type_id order by rand() limit 1;
case when po_question_id is null then
select question_id into po_question_id from t_question where question_id in (select question_id from t_exam_question group by question_id having count(question_id)=
(SELECT MIN(cnt) FROM (SELECT COUNT(*) cnt FROM t_exam_question GROUP BY question_id) t)) and lesson_sub_topic_id=pi_lesson_sub_topic_id and question_difficulty_id=pi_question_difficulty_id and question_type_id=pi_question_type_id order by rand() limit 1;
case when po_question_id is null then
select question_id into po_question_id from t_question where lesson_sub_topic_id=pi_lesson_sub_topic_id and question_difficulty_id=pi_question_difficulty_id and question_type_id=pi_question_type_id order by rand() limit 1;
else
set po_question_id=po_question_id;
end case;
else
set po_question_id=po_question_id;
end case;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_EXAM`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_EXAM`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_EXAM`(IN `pi_exam_name` text,IN `pi_exam_id` int,IN `pi_lesson_id` int,IN `pi_user_id` int,IN `pi_asked_year` text,IN `pi_exam_question_finished` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_exam
set 
exam_name=pi_exam_name,
lesson_id=pi_lesson_id,
user_id=pi_user_id,
asked_year=pi_asked_year,
exam_question_finished=pi_exam_question_finished
where exam_id=pi_exam_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_EXAM_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_EXAM_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_EXAM_QUESTION`(IN `pi_exam_question_id` int,IN `pi_exam_id` int,IN `pi_question_id` int,IN `pi_question_success_rate` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_exam_question
set exam_id=pi_exam_id,
question_id=pi_question_id,
question_success_rate=pi_question_success_rate
where exam_question_id=pi_exam_question_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_EXAM_QUESTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_EXAM_QUESTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_EXAM_QUESTION_TEMPLATE`(IN `pi_exam_question_template_id` int,IN `pi_exam_template_id` int,IN `pi_exam_question_id` int,IN `pi_exam_question_order` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_exam_question_template
set exam_template_id=pi_exam_template_id,
exam_question_id=pi_exam_question_id,
exam_question_order=pi_exam_question_order
where exam_question_template_id=pi_exam_question_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_EXAM_SUB_TOP_QUE_COUNT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_EXAM_SUB_TOP_QUE_COUNT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_EXAM_SUB_TOP_QUE_COUNT`(IN `pi_exam_id` int,IN `pi_lesson_sub_topic_id` int,IN `pi_question_difficulty_id` int,IN `pi_question_count` int,IN `pi_question_type_id` int,IN `pi_exam_sub_top_que_count_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_exam_sub_top_que_count
set exam_id=pi_exam_id,
lesson_sub_topic_id=pi_lesson_sub_topic_id,
question_difficulty_id=pi_question_difficulty_id,
question_count=pi_question_count,
question_type_id=pi_question_type_id
where exam_sub_top_que_count_id=pi_exam_sub_top_que_count_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_EXAM_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_EXAM_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_EXAM_TEMPLATE`(IN `pi_exam_template_id` int,IN `pi_exam_group_id` int,IN `pi_exam_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_exam_template
set exam_group_id=pi_exam_group_id,
exam_id=pi_exam_id
where exam_template_id=pi_exam_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_LESSON`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_LESSON`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_LESSON`(IN `pi_lesson_id` int,IN `pi_lesson_name` text,IN `pi_lesson_code` text,IN `pi_department_id` int,IN `pi_lesson_class` text,IN `pi_lesson_term` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_lesson
set lesson_name=pi_lesson_name,
lesson_code=pi_lesson_code,
department_id=pi_department_id,
lesson_class=pi_lesson_class,
lesson_term=pi_lesson_term
where lesson_id=pi_lesson_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_LESSON_SUB_TOPIC`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_LESSON_SUB_TOPIC`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_LESSON_SUB_TOPIC`(IN `pi_lesson_sub_topic_id` int,IN `pi_lesson_sub_topic_name` text,IN `pi_lesson_sub_topic_code` text,IN `pi_lesson_subject_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_lesson_sub_topic
set lesson_sub_topic_name=pi_lesson_sub_topic_name,
lesson_sub_topic_code=pi_lesson_sub_topic_code,
lesson_subject_id=pi_lesson_subject_id
where lesson_sub_topic_id=pi_lesson_sub_topic_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_LESSON_SUBJECT`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_LESSON_SUBJECT`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_LESSON_SUBJECT`(IN `pi_lesson_subject_id` int,IN `pi_lesson_subject_name` text,IN `pi_lesson_subject_code` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_lesson_subject
set lesson_subject_name=pi_lesson_subject_name,
lesson_subject_code=pi_lesson_subject_code
where lesson_subject_id=pi_lesson_subject_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_QUESTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_QUESTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_QUESTION`(IN `pi_question_id` int,IN `pi_question_content` text,IN `pi_question_photo` text,IN `pi_question_type_id` int,IN `pi_lesson_sub_topic_id` int,IN `pi_user_id` int,IN `pi_question_difficulty_id` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_question
set question_content=pi_question_content,
question_photo=pi_question_photo,
question_type_id=pi_question_type_id,
lesson_sub_topic_id=pi_lesson_sub_topic_id,
user_id=pi_user_id,
question_difficulty_id=pi_question_difficulty_id
where question_id=pi_question_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_QUESTION_OPTION`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_QUESTION_OPTION`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_QUESTION_OPTION`(IN `pi_question_option_id` int,IN `pi_question_option_content` text,IN `pi_question_option_photo` text,IN `pi_question_id` int,IN `pi_question_option_true` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_question_option
set question_option_content=pi_question_option_content,
question_option_photo=pi_question_option_photo,
question_id=pi_question_id,
question_option_true=pi_question_option_true
where question_option_id=pi_question_option_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_QUESTION_OPTION_TEMPLATE`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_QUESTION_OPTION_TEMPLATE`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_QUESTION_OPTION_TEMPLATE`(IN `pi_question_option_id` int,IN `pi_question_option_template_id` int,IN `pi_exam_question_template_id` int,IN `pi_question_option_order` int,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_question_option_template
set question_option_id=pi_question_option_id,
exam_question_template_id=pi_exam_question_template_id,
question_option_order=pi_question_option_order
where question_option_template_id=pi_question_option_template_id;
select row_count() into po_rows;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `PRO_UPD_T_USER`
-- ----------------------------
DROP PROCEDURE IF EXISTS `PRO_UPD_T_USER`;
DELIMITER ;;
CREATE DEFINER=`QUESTION_BANK`@`localhost` PROCEDURE `PRO_UPD_T_USER`(IN `pi_user_id` int,IN `pi_user_name` text,IN `pi_real_name` text,IN `pi_rank_id` int,IN `pi_active` text,IN `pi_user_password` text,IN `pi_password_changed` text,IN `pi_host_ip` text,IN `pi_department_id` int,IN `pi_user_task` text,OUT `po_rows` int)
BEGIN
	#Routine body goes here...
update t_user
set user_name=pi_user_name,
real_name=pi_real_name,
rank_id=pi_rank_id,
active=pi_active,
user_password=pi_user_password,
password_changed=pi_password_changed,
host_ip=pi_host_ip,
department_id=pi_department_id,
user_task=pi_user_task
where user_id=pi_user_id;
select row_count() into po_rows;
END
;;
DELIMITER ;
