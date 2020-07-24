-- phpMyAdmin SQL Dump
-- version 4.4.15.10
-- https://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 2020-07-24 15:38:34
-- 服务器版本： 5.7.30-log
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `testdb`
--

-- --------------------------------------------------------

--
-- 表的结构 `students`
--

CREATE TABLE IF NOT EXISTS `students` (
  `StudentId` int(20) NOT NULL,
  `StudentName` varchar(10) NOT NULL,
  `Gender` varchar(20) NOT NULL,
  `Birthday` date NOT NULL,
  `StudentIdNo` varchar(20) NOT NULL,
  `Age` int(10) NOT NULL,
  `PhoneNumber` varchar(20) NOT NULL,
  `StudentAddress` varchar(100) NOT NULL,
  `CardNo` varchar(20) NOT NULL,
  `ClassId` int(20) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=1315 DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `students`
--

INSERT INTO `students` (`StudentId`, `StudentName`, `Gender`, `Birthday`, `StudentIdNo`, `Age`, `PhoneNumber`, `StudentAddress`, `CardNo`, `ClassId`) VALUES
(257, '后羿', '男', '2020-08-08', '4408543452452', 0, '1356786786', '太阳', '1', 1000),
(369, '我猜', '男', '2020-06-06', '44081641651641', 2, '454541313', '高浮雕', 'daf', 1001);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`StudentId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `StudentId` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1315;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
