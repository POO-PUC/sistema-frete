import Head from 'next/head';
import styles from './dashboard.module.scss';
import { Header } from '../../components/Header';
import Link from 'next/link';
import MainLayout from '../../components/MainLayout';

export default function Home() {

  return (
    <MainLayout>
    <>
    <Header />
      <Head>
        <title>Fretes - Dashboard</title>
      </Head>
      <div className={styles.container}>

      </div>
    </>
    </MainLayout>
  );
}

