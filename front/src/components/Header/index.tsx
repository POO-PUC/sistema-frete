import styles from './styles.module.scss';
import Link from 'next/link';
import { FiLogOut } from 'react-icons/fi';
import Image from 'next/image';

export function Header() {

  return (
    <aside className={styles.sidebarContainer}>
      <div className={styles.sidebarContent}>
        <Link href="/home">
          <img src="/workflows-logo.png" width={190} height={100} alt="Logo Workflows" />
        </Link>

        <nav className={styles.menuNav}>
          <div className={styles.imageProfile}>
          <Image
              src={'/photoDefault.png'}
              alt="User Photo"
              className={styles.profilePhoto}
              width={50}
              height={50}
            />
          </div>
          <Link href="/estados">Estados</Link>
          <Link href="/cidades">Cidades</Link>
          <Link href="/clientes">Clientes</Link>
          <Link href="/funcionarios">Funcionários</Link>
          <Link href="/pessoas-fisicas">Pessoa Fisíca</Link>
          <Link href="/pessoas-juridicas">Pessoa Jurídica</Link>
          <Link href="/fretes">Fretes</Link>
          <Link href="/home"><FiLogOut color="#FFF" size={24} /></Link>
        </nav>
      </div>
    </aside>
  );
}
