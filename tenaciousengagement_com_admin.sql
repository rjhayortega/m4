-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Host: database4.lcn.com:3306
-- Generation Time: Jan 24, 2019 at 01:34 PM
-- Server version: 5.7.19
-- PHP Version: 7.2.14-1+0~20190113100742.14+stretch~1.gbpd83c69

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tenaciousengagement_com_admin`
--

-- --------------------------------------------------------

--
-- Table structure for table `mailList`
--

CREATE TABLE `mailList` (
  `id` int(5) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `location` varchar(255) DEFAULT NULL,
  `county` varchar(255) DEFAULT NULL,
  `is_pregnant` varchar(255) NOT NULL,
  `pregnancy_due_date` varchar(255) NOT NULL,
  `months_due` int(2) NOT NULL,
  `number_of_children` varchar(255) NOT NULL,
  `child1` varchar(255) NOT NULL,
  `child2` varchar(255) NOT NULL,
  `child3` varchar(255) NOT NULL,
  `child4` varchar(255) NOT NULL,
  `pampers` varchar(15) NOT NULL,
  `huggies` varchar(15) NOT NULL,
  `other` varchar(15) NOT NULL,
  `own_brand` varchar(15) NOT NULL,
  `area_code` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `visits` int(5) NOT NULL,
  `joinedDate` varchar(255) NOT NULL,
  `source` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mb_users`
--

CREATE TABLE `mb_users` (
  `UserID` int(11) NOT NULL,
  `firstname` varchar(150) NOT NULL,
  `lastname` varchar(150) NOT NULL,
  `email` varchar(255) NOT NULL,
  `username` varchar(100) NOT NULL,
  `mobileno` varchar(30) NOT NULL,
  `password` varchar(255) NOT NULL,
  `createddate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mb_users`
--

INSERT INTO `mb_users` (`UserID`, `firstname`, `lastname`, `email`, `username`, `mobileno`, `password`, `createddate`, `updatedate`) VALUES
(1, 'Admin', '', 'angelo@mydealdoc.ie', '', '', '123456', '2019-01-07 14:08:36', '2019-01-07 14:08:36');

-- --------------------------------------------------------

--
-- Table structure for table `segments`
--

CREATE TABLE `segments` (
  `id` int(5) NOT NULL,
  `name` text,
  `cmd` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `segments`
--

INSERT INTO `segments` (`id`, `name`, `cmd`) VALUES
(57, 'less than 5 months due', 'months_due<5'),
(58, 'bbb', 'joinedDate=2019-1-12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `mailList`
--
ALTER TABLE `mailList`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mb_users`
--
ALTER TABLE `mb_users`
  ADD PRIMARY KEY (`UserID`);

--
-- Indexes for table `segments`
--
ALTER TABLE `segments`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `mailList`
--
ALTER TABLE `mailList`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48157;
--
-- AUTO_INCREMENT for table `mb_users`
--
ALTER TABLE `mb_users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `segments`
--
ALTER TABLE `segments`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
